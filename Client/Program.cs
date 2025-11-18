using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<Client.Services.AnmodningService>();


builder.Services.AddScoped(sp => new HttpClient 
    { BaseAddress = new Uri("http://localhost:5044/") });

await builder.Build().RunAsync();