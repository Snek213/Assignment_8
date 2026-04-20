using Assignment_8.Data;
using Assignment_8.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddDbContext<Assignment_5Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Assignment_5Context")
    ?? throw new InvalidOperationException("Connection string 'Assignment_5Context' not found.")));


builder.Services.AddScoped<IMovieRepo, MovieRepoEf>();





// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
