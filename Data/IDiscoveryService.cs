using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IDiscoveryService
    {
        Task<List<Language>> GetLanguages();

        Task<List<Genre>> GetGenres(string productionType);


    }
}
