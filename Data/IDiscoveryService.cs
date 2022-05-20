using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IDiscoveryService
    {
        Task<List<Language>> GetLanguages();
        Task<List<Genre>> GetGenres(string productionType);
        Task<Results> DiscoveryProduction(string productionType, string language,
            string year, string minRating, string maxRating, string minRuntime, string maxRuntime, string personId, string genre);

    }
}