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

      //  private string uri = "http://localhost:7071/api";

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

        // only updates movie list - not list name 
        public async Task AddMovieToList(UserList userList, string movieId)
        {
            userList.Movies.Add(movieId);
            string listJson = JsonSerializer.Serialize(userList);
            HttpContent content = new StringContent(listJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri + "/UpdateList", content);
            Console.WriteLine(response.ToString());
        }

        // GET
        public async Task<List<Rating>> GetUserRatings(string userId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/GetUserRatings/" + userId);
            string message = await stringAsync;
            List<Rating> result = JsonSerializer.Deserialize<List<Rating>>(message);
            return result;
        }

        public async Task<List<Rating>> GetMovieRatings(string movieId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/GetMovieRatings/" + movieId);
            string message = await stringAsync;
            List<Rating> result = JsonSerializer.Deserialize<List<Rating>>(message);
            return result;
        }

        public async Task<Rating> GetUserMovieRating(string userId, string movieId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/GetUserMovieRating/" + movieId+"/"+userId);
            string message = await stringAsync;
            List<Rating> result = JsonSerializer.Deserialize<List<Rating>>(message);
            return result[0];
        }


        public async Task<List<Review>> GetUserReviews(string userId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/UserReviews/"+userId);
            string message = await stringAsync;
            List<Review> result = JsonSerializer.Deserialize<List<Review>>(message);
            return result;

        }
        public async Task<List<Review>> GetMovieReviews(string movieId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/MovieReviews/" + movieId);
            string message = await stringAsync;
            List<Review> result = JsonSerializer.Deserialize<List<Review>>(message);
            return result;

        }
        public async Task<List<UserList>> GetUserLists(string userId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/GetUserLists/"+userId);
            string message = await stringAsync;
            List<UserList> result = JsonSerializer.Deserialize<List<UserList>>(message);
            return result;
            
        }

        public async Task<List<string>> GetMoviesInList(string userId, string listName)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/GetMoviesInList/" + userId+"/"+listName);
            string message = await stringAsync;
            List<string> result = JsonSerializer.Deserialize<List<string>>(message);
            return result;

        }


        public async Task<List<string>> GetProductionIdsInListById(string listId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/GetMoviesInListById/" + listId);
            string message = await stringAsync;
            List<string> result = JsonSerializer.Deserialize<List<string>>(message);
            return result;

        }


        //TODO: implement GetProductionsInListById - add tvshows
        public async Task<List<Production>> GetProductionsInListById(string listId)
        {
            List<string> ProductionIds = await GetProductionIdsInListById(listId);

            List<Production> result = new List<Production>();
            Production prod;
            foreach(string id in ProductionIds)
            {
                prod = await productionService.GetProduction(id, "movie");
                result.Add(prod);
            }
            
            return result;

        }


        public async Task<string> GetUserId(AuthenticationStateProvider authenticationStateProvider)
        {
            var state = await authenticationStateProvider.GetAuthenticationStateAsync();
            string userId = state.User.Claims.Where(claim => claim.Type.Equals("sub")).Select(claim => claim.Value).FirstOrDefault() ?? String.Empty;
            userId = userId.Substring(userId.IndexOf("|") + 1);
            return userId;
        }

    
    }
}

