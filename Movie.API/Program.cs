using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.API.Extensions;
using Movies.Infrastructure;
using System.Configuration;
using FluentValidation.AspNetCore;
using Movies.Infrastructure.Seed;
using System;
using Microsoft.AspNetCore.Hosting;
using Movies.API.Helpers.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddRepositories();
builder.Services.AddApplicationLayer();



IConfiguration configuration = builder.Configuration;
builder.Services.AddDbContext<MoviesDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var serviceProvider = builder.Services.BuildServiceProvider();
var context = serviceProvider.GetService<MoviesDbContext>();
DbInitializer.SeedData(context);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
