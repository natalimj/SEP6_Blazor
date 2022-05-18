using System.Collections.Generic;
using System.Threading.Tasks;
using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IActorService
    {
        Task<Person> GetPerson(string id);

        //TODO: implement this method
        Task<List<Person>> SearchPerson(string query);
        Task<MovieCredits> GetMovieCredits(string id);
        Task<MovieCredits> GetTVCredits(string id);
    }
}