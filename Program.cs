using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SEP6_Blazor;
using SEP6_Blazor.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredModal();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductionService, ProductionService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IDiscoveryService, DiscoveryService>();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddSingleton<IProductionService, ProductionService>();
builder.Services.AddSingleton<IActorService, ActorService>();
builder.Services.AddSingleton<IUserService, UserService>();

// builder.Services.AddBootstrapBlazor();

await builder.Build().RunAsync();
