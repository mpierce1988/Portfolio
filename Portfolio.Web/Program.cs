using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portfolio.Web;
using Portfolio.Web.Services.BlogService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string baseUrl = builder.HostEnvironment.BaseAddress;
string? apiUrl = builder.Configuration["ApiUrl"];
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl ?? baseUrl) });
builder.Services.AddScoped<IBlogService, ApiBlogService>();

await builder.Build().RunAsync();