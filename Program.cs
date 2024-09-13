using Microsoft.EntityFrameworkCore;
using FinancialTransactionsAPI.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add this line to support controllers
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer(); // For OpenAPI/Swagger support
builder.Services.AddSwaggerGen(); // Add this line to support Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Add this line to enable Swagger
    app.UseSwaggerUI(); // Add this line to enable Swagger UI
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Add this line to map controllers

app.Run();

