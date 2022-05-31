using System.Collections.Generic;
using SEP6_Blazor.Data;
using SEP6_Blazor.Models;
using Xunit;
using Console = System.Console;

namespace BlazorUnitTests;

public class UnitTest1
{
    // ActorService
    [Fact]
    public void GetPerson()
    {
        var actorService = new ActorService();
        var searchResult = actorService.SearchPerson("Johnny Depp").Result[0].Id;
        var getPersonResult = actorService.GetPerson(searchResult.ToString()).Result.Id;
        Assert.Equal(searchResult, getPersonResult);
        
    }
    [Fact]
    public void SearchPerson()
    {
        var actorService = new ActorService();
        var searchResult = actorService.SearchPerson("Johnny Depp").Result[0].Id;
        var getPersonResult = actorService.GetPerson(searchResult.ToString()).Result.Id;
        Assert.Equal(searchResult, getPersonResult);
        
    }
    [Fact]
    public void GetMovieCredits()
    {
        var actorService = new ActorService();
        var resultSearch = actorService.SearchPerson("Johnny Depp").Result[0].Id.ToString();
        var resultGet = actorService.GetMovieCredits(resultSearch).Result;
        Assert.NotNull(resultGet);
        Assert.IsType<MovieCredits>(resultGet);
        
    }
    [Fact]
    public void GetTVCredits()
    {
        var actorService = new ActorService();
        var resultSearch = actorService.SearchPerson("Johnny Depp").Result[0].Id.ToString();
        var resultGet = actorService.GetTVCredits(resultSearch).Result;
        Assert.NotNull(resultGet);
        Assert.IsType<MovieCredits>(resultGet);
        
    }
    // DiscoveryService
    [Fact]
    public void GetLanguages()
    {
        var discoveryService = new DiscoveryService();
        var resultGet = discoveryService.GetLanguages().Result;
        Assert.NotNull(resultGet);
        Assert.NotEmpty(resultGet);
        Assert.IsType<List<Language>>(resultGet);
    }
    [Fact]
    public void GetGenres()
    {
        var discoveryService = new DiscoveryService();
        var resultGet = discoveryService.GetGenres("movie").Result;
        Assert.NotNull(resultGet);
        Assert.NotEmpty(resultGet);
        Assert.IsType<List<Genre>>(resultGet);
    }
    [Fact]
    public void DiscoveryProduction()
    {
        var discoveryService = new DiscoveryService();
        var resultGet = discoveryService.DiscoveryProduction("movie","","","","","","","","").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Results>(resultGet);
    }
    
    // ProductionService
    [Fact]
    public void SearchProduction()
    {
        var productionService = new ProductionService();
        var resultSearch = productionService.SearchProduction("Uncharted", "movie").Result.ProductionResults[0].Id.ToString();
        var resultGet = productionService.GetProduction(resultSearch, "movie").Result.Id.ToString();
        Assert.Equal(resultGet,resultSearch);
    }
    [Fact]
    public void GetProduction()
    {
        var productionService = new ProductionService();
        var resultSearch = productionService.SearchProduction("Harry Potter", "movie").Result.ProductionResults[0].Id.ToString();
        var resultGet = productionService.GetProduction(resultSearch, "movie").Result.Id.ToString();
        Assert.Equal(resultGet,resultSearch);
    }
    
    [Fact]
    public void GetProductionImagesUrl()
    {
        var productionService = new ProductionService();
        var resultSearch = productionService.SearchProduction("Harry Potter", "movie").Result.ProductionResults[0].Id.ToString();
        var resultGet = productionService.GetProductionImagesUrl(resultSearch, "movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Images>(resultGet);
    }
    
    [Fact]
    public void GetCast()
    {
        var productionService = new ProductionService();
        var resultSearch = productionService.SearchProduction("Harry Potter", "movie").Result.ProductionResults[0].Id.ToString();
        var resultGet = productionService.GetCast(resultSearch, "movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Cast>(resultGet);
    }
    [Fact]
    public void GetDirector()
    {
        var productionService = new ProductionService();
        var resultSearch = productionService.SearchProduction("Harry Potter", "movie").Result.ProductionResults[0].Id.ToString();
        var resultGet = productionService.GetDirector(resultSearch, "movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<List<Director>>(resultGet);
    }
    [Fact]
    public void GetRecommendedProductions()
    {
        var productionService = new ProductionService();
        var resultSearch = productionService.SearchProduction("Harry Potter", "movie").Result.ProductionResults[0].Id.ToString();
        var resultGet = productionService.GetRecommendedProductions(resultSearch, "movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Results>(resultGet);
    }
    
    [Fact]
    public void GetSimilarProductions()
    {
        var productionService = new ProductionService();
        var resultSearch = productionService.SearchProduction("Harry Potter", "movie").Result.ProductionResults[0].Id.ToString();
        var resultGet = productionService.GetSimilarProductions(resultSearch, "movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Results>(resultGet);
    }
    [Fact]
    public void GetPopularProductions()
    {
        var productionService = new ProductionService();
        var resultGet = productionService.GetPopularProductions("movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Results>(resultGet);
    }
    [Fact]
    public void GetLatestProduction()
    {
        var productionService = new ProductionService();
        var resultGet = productionService.GetLatestProduction("movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Production>(resultGet);
    }
    [Fact]
    public void GetTopRatedProduction()
    {
        var productionService = new ProductionService();
        var resultGet = productionService.GetTopRatedProduction("movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Results>(resultGet);
    }
    [Fact]
    public void GetUpcomingMovies()
    {
        var productionService = new ProductionService();
        var resultGet = productionService.GetUpcomingMovies().Result;
        Assert.NotNull(resultGet);
        Assert.IsType<Results>(resultGet);
    }
    [Fact]
    public void GetProductionReviews()
    {
        var productionService = new ProductionService();
        var resultSearch = productionService.SearchProduction("Harry Potter", "movie").Result.ProductionResults[0].Id.ToString();
        var resultGet = productionService.GetProductionReviews(resultSearch,"movie").Result;
        Assert.NotNull(resultGet);
        Assert.IsType<TMDBReview>(resultGet);
    }
    // UserService
    [Fact]
    public void Test4()
    {
        Assert.True(true);
    }
}