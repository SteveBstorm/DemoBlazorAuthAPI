using DemoConsoAPI;
using DemoConsoAPI.Infrastructure;
using DemoConsoAPI.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7158/api/") });

builder.Services.AddTransient<TokenInterceptor>();

builder.Services.AddHttpClient("WithToken", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://localhost:7158/api/");
}).AddHttpMessageHandler<TokenInterceptor>();

builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<AuthenticationStateProvider, MyStateProvider>();

await builder.Build().RunAsync();


/*
 1) Créer le state provider
 2) Ajouter au program.cs 
    builder.Services.AddAuthorizationCore();
    builder.Services.AddSingleton<AuthenticationStateProvider, MyStateProvider>();
 3) Modifier le app.razor
    <CascadingAuthenticationState>
    <AuthorizeRouteView>
 */