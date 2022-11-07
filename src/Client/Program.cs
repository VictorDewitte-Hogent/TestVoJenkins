using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using Shared.Boxes;
using Client.Boxes;
using Client.Shared;
using Shared.Products;
using Client.Products;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBoxService, BoxService>();
builder.Services.AddScoped<IProductService,ProductService>();
await builder.Build().RunAsync();
