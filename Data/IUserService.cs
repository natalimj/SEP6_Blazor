﻿using Microsoft.AspNetCore.Components.Authorization;
using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IUserService
    {
        Task AddRating(Rating rating);
        Task UpdateRating(Rating rating);
        Task DeleteRating(string ratingId);
        Task<List<Rating>> GetUserRatings(string userId);
        Task<List<Rating>> GetProductionRatings(string productionId, string productionType); // only from DB 

        Task AddReview(Review review);
        Task UpdateReview(Review review);
        Task DeleteReview(string reviewId);
        Task<List<Review>> GetUserReviews(string userId);
        Task<List<Review>> GetProductionReviews(string productionId, string productionType); //Only from DB 


        Task AddList(UserList userList); //create an empty list
        Task AddProductionToList(UserList userList, string productionId, string productionType);
        Task DeleteList(string listId);
        Task<List<UserList>> GetUserLists(string userId);  // get user lists
        Task<List<Production>> GetProductionsInList(string listId);

        Task<string> GetUserId(AuthenticationStateProvider authenticationStateProvider);

    }
}
