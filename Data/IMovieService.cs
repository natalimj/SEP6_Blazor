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
    }
}
