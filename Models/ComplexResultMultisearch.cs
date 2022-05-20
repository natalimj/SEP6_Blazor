namespace SEP6_Blazor.Models
{
    public class ComplexResultMultisearch
    {
        public Results ProductionResults { get; set; }
        public Results RecommendedResults { get; set; }
        public Results SimilarResults { get; set; }
        
        public ComplexResultMultisearch(Results movieResults, Results recommendedResults, Results similarResults)
        {
            ProductionResults = movieResults;
            RecommendedResults = recommendedResults;
            SimilarResults = similarResults;
        }
    }
}