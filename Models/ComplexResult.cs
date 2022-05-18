using System.Collections.Generic;

namespace SEP6_Blazor.Models
{
    public class ComplexResult
    {
        public Results movieResults { get; set; }
        public Results tvSeriesResult { get; set; }
        public List<Person> actorResuls { get; set; }

        public ComplexResult(Results movieResults, Results tvSeriesResult, List<Person> actorResuls)
        {
            this.movieResults = movieResults;
            this.actorResuls = actorResuls;
            this.tvSeriesResult = tvSeriesResult;
        }
    }
}