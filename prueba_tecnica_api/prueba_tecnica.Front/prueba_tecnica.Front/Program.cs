var builder = WebApplication.CreateBuilder(args);

// Servicios necesarios para servir Blazor WebAssembly
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();

// Mapeo de fallback para Blazor WebAssembly
app.MapFallbackToFile("index.html");

app.Run();