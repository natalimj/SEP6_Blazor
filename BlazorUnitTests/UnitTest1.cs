
using BootstrapBlazor.Components;
using SEP6_Blazor.Data;
using Xunit;
using Console = System.Console;

namespace BlazorUnitTests;

public class UnitTest1
{
    // ActorService
    [Fact]
    public void SearchAndGetPerson()
    {
        var actorService = new ActorService();
        var searchResult = actorService.SearchPerson("Johnny Depp").Result[0].Id;
        var getPersonResult = actorService.GetPerson(searchResult.ToString()).Result.Id;
        Console.Write(searchResult);
        Console.Write(getPersonResult);
        Assert.Equal(searchResult, getPersonResult);
        
    }
    // DiscoveryService
    [Fact]
    public void Test2()
    {
        var discoveryService = new DiscoveryService();
        var discoveryResult = discoveryService.DiscoveryProduction("", "", "2017", "", "", "", "", "", "").Result.ProductionResults[0].MovieName;
        Console.Write(discoveryResult);
        Assert.True(true);
    }
    [Fact]
    public void Test3()
    {
        Assert.True(true);
    }
    [Fact]
    public void Test4()
    {
        Assert.True(true);
    }
}