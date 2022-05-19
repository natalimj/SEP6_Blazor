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

        public async Task AddRating(Rating rating)
        {
            string ratingJson = JsonSerializer.Serialize(rating);
            HttpContent content = new StringContent(ratingJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/AddRating", content);
            Console.WriteLine(response.ToString());
        }
        public async Task AddReview(Review review)
        {
            string reviewJson = JsonSerializer.Serialize(review);
            HttpContent content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/AddReview", content);
            Console.WriteLine(response.ToString());
        }

        //creates an empty list
        public async Task AddList(UserList userList)
        {
            string listJson = JsonSerializer.Serialize(userList);
            HttpContent content = new StringContent(listJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/CreateList", content);
            Console.WriteLine(response.ToString());
        }

        //DELETE
        public async Task DeleteRating(string ratingId)
        {
            HttpContent content = new StringContent(ratingId, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri+"/DeleteRatingById/"+ratingId,content);
            Console.WriteLine(response.ToString());
        }

        public async Task DeleteReview(string reviewId)
        {
            HttpContent content = new StringContent(reviewId, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri+"/DeleteReviewById/"+reviewId,content);
            Console.WriteLine(response.ToString());
        }

        public async Task DeleteList(string listId)
        {
            HttpContent content = new StringContent(listId, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri+"/DeleteListById/"+listId,content);
            Console.WriteLine(response.ToString());
        }

        //UPDATE
        public async Task UpdateRating(Rating rating)
        {
            string ratingJson = JsonSerializer.Serialize(rating);
            HttpContent content = new StringContent(ratingJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/UpdateRating", content);
            Console.WriteLine(response.ToString());
        }

        public async Task UpdateReview(Review review)
        {
            string reviewJson = JsonSerializer.Serialize(review);
            HttpContent content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/UpdateReview", content);
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
            if(result != null && result.Count > 0)
            {
                return result[0];
            }
            return new Rating();
        }

        public async Task<Review> GetUserReview(string userId, string productionId, string productionType)
        {
            List<Review> result = new List<Review>();
            Task<string> stringAsync = client.GetStringAsync(uri + "/UserReview/" + productionId + "/" + userId + "/" + productionType);
            string message = await stringAsync;
            result = JsonSerializer.Deserialize<List<Review>>(message);

            if(result != null && result.Count > 0)
            {
                return result[0];
            }
            return new Review();
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
            item.ProductionId=productionId;
            item.Type = productionType;
            userList.ListItems.Add(item);
            string listJson = JsonSerializer.Serialize(userList);
            HttpContent content = new StringContent(listJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/UpdateList", content);
            Console.WriteLine(response.ToString());
        }
        
        public async Task<List<ListItem>> GetListItemsById(String listId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/GetProductionsInListById/" + listId);
            string message = await stringAsync;

            List<UserList>  result = JsonSerializer.Deserialize<List<UserList>>(message);

            if (result != null && result.Count > 0)
            {
                return result[0].ListItems;
            }
            return new UserList().ListItems;

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

        //movies and tv shows with 5 star
        public async Task<List<Production>> GetLikedProductions(string userId)
        {
            List<Rating> ratings= await GetUserRatings(userId);

            List<Production> productions = new List<Production>();

            foreach(Rating rating in ratings)
            {
                if(rating.UserRating == 5)
                {
                    Production production = await productionService.GetProduction(rating.ProductionId, rating.Type);
                    productions.Add(production);
                }
            }
            return productions;
        }
 

    }
}

