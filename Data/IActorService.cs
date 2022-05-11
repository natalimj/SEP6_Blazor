using SEP6_Blazor.Models;

namespace SEP6_Blazor.Data
{
    public interface IActorService
    {
        Task<Person> GetPerson(string id);
        Task<MovieCredits> GetMovieCredits(string id);

    }
}
