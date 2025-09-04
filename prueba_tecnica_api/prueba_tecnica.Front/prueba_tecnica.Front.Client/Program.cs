using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using prueba_tecnica.Front.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// HttpClient apunta a la API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:2021/") // Cambia el puerto si tu API usa otro
});

builder.Services.AddScoped<ProductApiService>();

await builder.Build().RunAsync();
