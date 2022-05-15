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
        Task<List<Movie>> GetRecommendedMovies(string id);
        Task<List<Movie>> GetSimilarMovies(string id); // by looking at keywords and genres.
        Task<List<Movie>> GetPopularMovies();
        Task<List<Movie>> GetUpcomingMovies();
        Task<List<Movie>> GetTopRatedMovies();

    }
}
