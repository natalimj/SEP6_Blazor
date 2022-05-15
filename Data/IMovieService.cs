using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IMovieService
    {
        Task<Results> SearchMovie(string query);
        Task<Movie> GetMovie(string id);
        Task<Images> GetMovieImagesUrl(string id); 
        Task<Cast> GetCast(string id);
        Task<List<Director>> GetDirector(string id);
        Task<Results> GetRecommendedMovies(string id);
        Task<Results> GetSimilarMovies(string id); // by looking at keywords and genres.
        Task<Results> GetPopularMovies();
        Task<Results> GetUpcomingMovies();
        Task<Results> GetTopRatedMovies();

    }
}
