using System.Collections.Generic;
using System.Threading.Tasks;
using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IProductionService
    {
        Task<Results> SearchProduction(string query, string productionType);
        Task<Production> GetProduction(string id, string productionType);
        Task<Images> GetProductionImagesUrl(string id, string productionType);
        Task<Cast> GetCast(string id, string productionType);
        Task<List<Director>> GetDirector(string id, string productionType);
        Task<Results> GetRecommendedProductions(string id, string productionType);
        Task<Results> GetSimilarProductions(string id, string productionType);
        Task<Results> GetPopularProductions(string productionType);
        Task<Production> GetLatestProduction(string productionType);
        Task<Results> GetTopRatedProduction(string productionType);
        Task<Results> GetUpcomingMovies();
        Task<TMDBReview> GetProductionReviews(string id, string productionType);
    }
}