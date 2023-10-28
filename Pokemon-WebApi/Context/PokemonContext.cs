using Microsoft.EntityFrameworkCore;
using Pokemon_WebApi.Models.Entities;

namespace Pokemon_WebApi.Context;

public class PokemonContext : DbContext
{
    public PokemonContext(DbContextOptions options)
        : base(options)
    {

    }

    public DbSet<Pokemon> Pokemons { get; set; }
}
