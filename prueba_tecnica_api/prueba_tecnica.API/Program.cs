using Microsoft.EntityFrameworkCore;
using prueba_tecnica.Application.FormValidations.FormProduct;
using prueba_tecnica.Application.Services;
using prueba_tecnica.Domain.Interfaces;
using prueba_tecnica.Infrastructure.Data;
using prueba_tecnica.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=prueba_tecnica_db.db"));
// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Add Form Validations
builder.Services.AddScoped<IFormProduct, FormProduct>();

// Add Mapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<prueba_tecnica.Application.Mapper.AutoMapper>());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFront", policy =>
    {
        policy.WithOrigins(
            "http://localhost:2023",
            "https://localhost:2023",
            "http://localhost:2022",
            "https://localhost:2022"
            )
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFront");

app.UseAuthorization();

app.MapControllers();

app.Run();
