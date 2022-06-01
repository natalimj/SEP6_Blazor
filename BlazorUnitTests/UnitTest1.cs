using System.Collections.Generic;
using DeepEqual.Syntax;
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
    public async void RatingCRUD()
    {
        var userService = new UserService();
        Rating nullRating = new Rating();
        Rating rating1 = new Rating("0000","1111","movie",1);
        Rating rating2 = new Rating("0000","2222","movie",2);
        await userService.AddRating(rating1); 
        await userService.AddRating(rating2);
        var getResult1 = userService.GetUserRating("0000", "1111", "movie").Result;
        var getResult2 = userService.GetUserRating("0000", "2222", "movie").Result;
        rating1.Id = getResult1.Id;
        rating2.Id = getResult2.Id;
        getResult1.ShouldDeepEqual(rating1);
        getResult2.ShouldDeepEqual(rating2);
        var getMultipleResults = userService.GetUserRatings("0000").Result;
        getMultipleResults[0].ShouldDeepEqual(rating1);
        getMultipleResults[1].ShouldDeepEqual(rating2);
        await userService.DeleteRating(getResult1.Id);
        var getResult1Deleted = userService.GetUserRating("0000", "1111", "movie").Result;
        getResult1Deleted.ShouldDeepEqual(nullRating);
        await userService.DeleteRating(getResult2.Id);
        var getResult2Deleted = userService.GetUserRating("0000", "2222", "movie").Result;
        getResult1Deleted.ShouldDeepEqual(nullRating);
    }

    [Fact]
    public async void ReviewCRUD()
    {
        var userService = new UserService();
        Review nullRating = new Review();
        Review review1 = new Review("0000","1111","movie","review1");
        Review review2 = new Review("0000","2222","movie","review2");
        await userService.AddReview(review1); 
        await userService.AddReview(review2);
        var getResult1 = userService.GetUserReview("0000", "1111", "movie").Result[0];
        var getResult2 = userService.GetUserReview("0000", "2222", "movie").Result[0];
        review1.Id = getResult1.Id;
        review2.Id = getResult2.Id;
        getResult1.ShouldDeepEqual(review1);
        getResult2.ShouldDeepEqual(review2);
        var getMultipleResults = userService.GetUserReviews("0000").Result;
        getMultipleResults[0].ShouldDeepEqual(review1);
        getMultipleResults[1].ShouldDeepEqual(review2);
        await userService.DeleteReview(getResult1.Id);
        var getResult1Deleted = userService.GetUserReview("0000", "1111", "movie").Result;
        Assert.Empty(getResult1Deleted);
        await userService.DeleteReview(getResult2.Id);
        var getResult2Deleted = userService.GetUserReview("0000", "2222", "movie").Result;
        Assert.Empty(getResult2Deleted);
    }
    
    [Fact]
    public async void ListCRUD()
    {
        var userService = new UserService();
        UserList list1 = new UserList("0000","list1",new List<ListItem>());
        UserList list2 = new UserList("0000","list2",new List<ListItem>());
        await userService.AddList(list1); 
        await userService.AddList(list2);
        var getMultipleResults = userService.GetUserLists("0000").Result;
        list1.Id = getMultipleResults[0].Id;
        list2.Id = getMultipleResults[1].Id;
        getMultipleResults[0].ShouldDeepEqual(list1);
        getMultipleResults[1].ShouldDeepEqual(list2);
        await userService.DeleteList(getMultipleResults[0].Id);
        await userService.DeleteList(getMultipleResults[1].Id);
        var getResultsDeleted = userService.GetUserLists("0000").Result;
        Assert.Empty(getResultsDeleted);
    }
}