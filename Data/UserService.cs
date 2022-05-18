using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using SEP6_Blazor.Models;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP6_Blazor.Data
{
    public class UserService : IUserService
    {

        private string uri = "https://sep6azurefunctions.azurewebsites.net/api"; 
        private readonly HttpClient client = new ();

        private readonly IProductionService productionService = new ProductionService();

        //ADD
        public async Task AddRating(Rating rating)
        {
            string ratingJson = JsonSerializer.Serialize(rating);
            HttpContent content = new StringContent(ratingJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri + "/AddOrUpdateRating", content);
            Console.WriteLine(response.ToString());
        }
        public async Task AddReview(Review review)
        {
            string reviewJson = JsonSerializer.Serialize(review);
            HttpContent content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri + "/AddOrUpdateReview", content);
            Console.WriteLine(response.ToString());
        }

        //creates an empty list
        public async Task AddList(UserList userList)
        {
            string listJson = JsonSerializer.Serialize(userList);
            HttpContent content = new StringContent(listJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri + "/CreateList", content);
            Console.WriteLine(response.ToString());
        }

        //DELETE
        public async Task DeleteRating(string ratingId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/DeleteRatingById/{ratingId}");
            Console.WriteLine(response.ToString());
        }

        public async Task DeleteReview(string reviewId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/DeleteReviewById/{reviewId}");
            Console.WriteLine(response.ToString());
        }

        public async Task DeleteList(string listId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/DeleteListById/{listId}");
            Console.WriteLine(response.ToString());
        }

        //UPDATE
        public async Task UpdateRating(Rating rating)
        {
            string ratingJson = JsonSerializer.Serialize(rating);
            HttpContent content = new StringContent(ratingJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri + "/UpdateRating", content);
            Console.WriteLine(response.ToString());
        }

        public async Task UpdateReview(Review review)
        {
            string reviewJson = JsonSerializer.Serialize(review);
            HttpContent content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri + "/UpdateReview", content);
            Console.WriteLine(response.ToString());
        }


        // GET
        public async Task<List<Rating>> GetUserRatings(string userId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/UserRatings/" + userId);
            string message = await stringAsync;
            List<Rating> result = JsonSerializer.Deserialize<List<Rating>>(message);
            return result;
        }

        public async Task<List<Review>> GetUserReviews(string userId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/UserReviews/"+userId);
            string message = await stringAsync;
            List<Review> result = JsonSerializer.Deserialize<List<Review>>(message);
            return result;

        }

        public async Task<List<UserList>> GetUserLists(string userId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/UserLists/"+userId);
            string message = await stringAsync;
            List<UserList> result = JsonSerializer.Deserialize<List<UserList>>(message);
            return result;
            
        }

        public async Task<string> GetUserId(AuthenticationStateProvider authenticationStateProvider)
        {
            var state = await authenticationStateProvider.GetAuthenticationStateAsync();
            string userId = state.User.Claims.Where(claim => claim.Type.Equals("sub")).Select(claim => claim.Value).FirstOrDefault() ?? String.Empty;
            userId = userId.Substring(userId.IndexOf("|") + 1);
            return userId;
        }

        //DONE

        public async Task<List<Rating>> GetProductionRatings(string productionId, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/ProductionRatings/" + productionId + "/" + productionType);
            string message = await stringAsync;
            List<Rating> result = JsonSerializer.Deserialize<List<Rating>>(message);
            return result;
        }
        public async Task<Rating> GetUserRating(string userId, string productionId, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/UserRating/" + productionId + "/" + userId + "/" + productionType);
            string message = await stringAsync;
            List<Rating> result = JsonSerializer.Deserialize<List<Rating>>(message);
            return result[0];
        }

        public async Task<List<Review>> GetProductionReviews(string productionId, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/ProductionReview/" + productionId + "/" + productionType);
            string message = await stringAsync;
            List<Review> result = JsonSerializer.Deserialize<List<Review>>(message);
            return result;
        }

        public async Task AddProductionToList(UserList userList, string productionId, string productionType)
        {
            ListItem item = new ListItem();
            item.ProductionId = productionId;
            item.Type = productionType;
            userList.ListItems.Add(item);
            string listJson = JsonSerializer.Serialize(userList);
            HttpContent content = new StringContent(listJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri + "/UpdateList", content);
            Console.WriteLine(response.ToString());
        }
        
        public async Task<List<ListItem>> GetListItemsById(String listId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/GetProductionsInListById/" + listId);
            string message = await stringAsync;
            UserList  result = JsonSerializer.Deserialize<UserList>(message);
            return result.ListItems;
        }

        public async Task<List<Production>> GetProductionsInList(string listId)
        {
            List<ListItem> ListItems = await GetListItemsById(listId);

            List<Production> result = new List<Production>();

            Production prod;
            foreach (ListItem item in ListItems)
            {
                if (item.Type.Equals("movie"))
                {
                    prod = await productionService.GetProduction(item.ProductionId, "movie");
                    result.Add(prod);
                } else
                {
                    prod = await productionService.GetProduction(item.ProductionId, "tv");
                    result.Add(prod);
                }              
            }
            return result;
        }

    }
}

