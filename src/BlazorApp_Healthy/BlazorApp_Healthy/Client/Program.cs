using BlazorApp_Healthy.Client;
using BlazorApp_Healthy.Client.Services.Comon;
using BlazorApp_Healthy.Client.Services.DataService;
using BlazorApp_Healthy.Client.Services.Recipes;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register IDataService and Repository
builder.Services.AddScoped<IDataService, HttpDataService>();
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));


builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

await builder.Build().RunAsync();
