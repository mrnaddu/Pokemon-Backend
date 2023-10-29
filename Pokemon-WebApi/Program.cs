using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Pokemon_WebApi.Applications.Abstract;
using Pokemon_WebApi.Applications.Implementation;
using Pokemon_WebApi.Context;
using Pokemon_WebApi.Controllers.Abastract;
using Pokemon_WebApi.Controllers.Implementation;
using Pokemon_WebApi.Repositories.Abastract;
using Pokemon_WebApi.Repositories.Implementation;
using Pokemon_WebApi.Repository.Abastract;
using Pokemon_WebApi.Repository.Implementation;
using Serilog;
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

builder.Services.AddScoped<IPokemonRepository,PokemonRepository>();

// Mapping
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.WithMethods("GET", "POST", "DELETE", "PUT");
        policy.WithOrigins("http://localhost:4200/");
    });
});

// Serilog 
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Static files config for image link
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Uploads/img")),
    RequestPath = "/Resources"
});

app.UseCors();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
