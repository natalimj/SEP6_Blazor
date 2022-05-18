using Microsoft.AspNetCore.Components.Authorization;
using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IUserService
    {
        Task AddRating(Rating rating);
        Task UpdateRating(Rating rating);
        Task DeleteRating(string ratingId);
        Task<List<Rating>> GetUserRatings(string userId);
        Task<List<Rating>> GetMovieRatings(string movieId); // only from DB 

        Task<Rating> GetUserMovieRating(string userId, string movieId);

        Task AddReview(Review review);
        Task UpdateReview(Review review);
        Task DeleteReview(string reviewId);
        Task<List<Review>> GetUserReviews(string userId);
        Task<List<Review>> GetMovieReviews(string movieId); //Only from DB 

        Task AddList(UserList userList); //create an empty list
        Task AddMovieToList(UserList userList, string movieId); 
        Task DeleteList(string listId);
        Task<List<UserList>> GetUserLists(string userId);  // get user lists
        Task<List<string>> GetMoviesInList(string userId, string listName);

        Task<List<string>> GetProductionIdsInListById(string listId);
        Task<List<Production>> GetProductionsInListById(string listId);

        Task<string> GetUserId(AuthenticationStateProvider authenticationStateProvider);

    }
}
