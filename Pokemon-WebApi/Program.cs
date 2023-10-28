using Microsoft.EntityFrameworkCore;
using Pokemon_WebApi.Context;
using Pokemon_WebApi.Controllers.Abastract;
using Pokemon_WebApi.Controllers.Implementation;
using Pokemon_WebApi.Repository.Abastract;
using Pokemon_WebApi.Repository.Implementation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Database Injection
builder.Services.AddDbContext<PokemonContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Pokemon")));

// Dependency Injection
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddTransient<IPokemonRepository, PokemonRepostory>();

builder.Services.AddTransient<IPokemonController, PokemonController>();

// Mapping
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
