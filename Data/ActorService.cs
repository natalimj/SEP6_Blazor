using System;
using System.Collections.Generic;
using System.Net.Http;
using SEP6_Blazor.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP6_Blazor.Data
{
    public class ActorService : IActorService
    {
        private string uri = "https://api.themoviedb.org/3/";
        private string apiKey = "?api_key=63335424114024b0bdbf981fe8c972e0";
        private readonly HttpClient client = new();

        public async Task<Person> GetPerson(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "person/" + id + apiKey);
            string message = await stringAsync;
            Person person = JsonSerializer.Deserialize<Person>(message);
            person.MovieCredits = await GetMovieCredits(id);

            return person;
        }

        public async Task<List<Person>> SearchPerson(string query)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "search/person" + apiKey + "&query=" + query);
            string message = await stringAsync;
            PersonResults personResults = JsonSerializer.Deserialize<PersonResults>(message);         
            List<Person> results = new List<Person>();  
            Person person = new Person();
            if(personResults != null)
            {
                foreach (PersonResult personResult in personResults.Results)
                {
                    person = await GetPerson(personResult.Id.ToString());
                    results.Add(person);
                }
            }
            return results;
        }

        public async Task<MovieCredits> GetMovieCredits(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "person/" + id + "/movie_credits" + apiKey);
            string message = await stringAsync;
            MovieCredits result = JsonSerializer.Deserialize<MovieCredits>(message);
            return result;
        }

        public async Task<MovieCredits> GetTVCredits(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "person/" + id + "/tv_credits" + apiKey);
            string message = await stringAsync;
            MovieCredits result = JsonSerializer.Deserialize<MovieCredits>(message);
            return result;
        }
    }
}