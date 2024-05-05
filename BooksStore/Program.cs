using Blazored.LocalStorage;
using BooksStore;
using BooksStore.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<DemoLoggingHandler>();
builder.Services.AddHttpClient("BooksStore.API", httpClient => 
        httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]!)).AddHttpMessageHandler<DemoLoggingHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BooksStore.API")); 
builder.Services.AddScoped<ILoggingService, ConsoleLoggingService>();
builder.Services.AddScoped<IBooksService, LocalBooksService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<AppStateContainer>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtCustomAuthenticationStateProvider>();
await builder.Build().RunAsync();