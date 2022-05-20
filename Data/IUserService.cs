using Microsoft.AspNetCore.Components.Authorization;
using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IUserService
    {
        Task AddRating(Rating rating);
        Task UpdateRating(Rating rating);
       
        // user's rating list for my contributions page
        Task<List<Rating>> GetUserRatings(string userId);

        // User's rating for a movie/tv show
        Task<Rating> GetUserRating(string userId, string productionId, string productionType);
        Task AddReview(Review review);

        // list of reviews for my contributions page
        Task<List<Review>> GetUserReviews(string userId);

        // user review for a production - for movie and tv series page
        Task<List<Review>> GetUserReview(string userId, string productionId, string productionType);

        // create a new list and add movie
        Task AddList(UserList userList);

        // add movie to an existing list
        Task AddProductionToList(UserList userList, string productionId, string productionType);
        Task<List<UserList>> GetUserLists(string userId);  
        Task<List<Production>> GetProductionsInList(string listId);

        Task<List<Production>> GetLikedProductions(string userId);
        Task<string> GetUserId(AuthenticationStateProvider authenticationStateProvider);


        /* probably we don't need these methods - delete later */
        Task DeleteRating(string ratingId);
        Task DeleteList(string listId);
        Task DeleteReview(string reviewId);
        Task UpdateReview(Review review);
        // reviews for a production from cosmos db.  
        Task<List<Review>> GetProductionReviews(string productionId, string productionType);
        // all ratings for a production - only from cosmos db 
        Task<List<Rating>> GetProductionRatings(string productionId, string productionType); 


    }
}
