using Microsoft.EntityFrameworkCore;
using Pokemon_WebApi.Applications.Abstract;
using Pokemon_WebApi.Applications.Implementation;
using Pokemon_WebApi.Context;
using Pokemon_WebApi.Controllers.Abastract;
using Pokemon_WebApi.Controllers.Implementation;
using Pokemon_WebApi.Repositories.Abastract;
using Pokemon_WebApi.Repositories.Implementation;
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
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<IPokemonController, PokemonController>();

builder.Services.AddScoped<IPokemonService,PokemonService>();

builder.Services.AddScoped(typeof(IEfCoreRepository<>), typeof(EfCoreRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
