using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface ITVService
    {
        Task<Results> SearchTVShow(string query);
        Task<TVShow> GetTVShow(string id);
        Task<Images> GetTVShowImagesUrl(string id);
        Task<Cast> GetTVShowCast(string id);
    }
}
