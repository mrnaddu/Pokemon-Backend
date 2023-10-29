using Microsoft.EntityFrameworkCore;
using Pokemon_WebApi.Context;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Repositories.Abastract;

namespace Pokemon_WebApi.Repositories.Implementation;

public class PokemonRepository 
    : IPokemonRepository
{
    private readonly PokemonContext _context;
    public PokemonRepository(
        PokemonContext context)
    {
        _context = context;
    }

    public async Task<Pokemon> CreateAsync(
        Pokemon pokemon)
    {
        var data = await _context.Pokemons.AddAsync(pokemon);
        data.Entity.IsActive = true;
        await _context.SaveChangesAsync();  
        return data.Entity;
    }

    public async Task<Pokemon> DeleteAsync(
        Guid id)
    {
        var data = await GetAsync(id);
        if(data != null)
        {
            data.IsDelete = true;
            _context.Pokemons.Update(data);  
            await _context.SaveChangesAsync();
        }
        return data;
    }

    public async Task<Pokemon> FindByNameAsync(
        string pokemonName)
    {
        var data = _context.Pokemons.AsQueryable();
        var result =
            await data.AsNoTracking()
            .FirstOrDefaultAsync(
                x=> x.PokemonName == pokemonName);
        return result;
    }

    public async Task<List<Pokemon>> GetAllAsync()
    {
        var data =  _context.Pokemons.AsQueryable();
        var result = 
            await data.AsNoTracking()
            .Where(
                x=> x.IsDelete == false 
                && x.IsActive == true)
            .OrderBy(
                x => x.Id)
            .ToListAsync();
        return result;
    }

    public async Task<Pokemon> GetAsync(
        Guid id)
    {
        var data =  _context.Pokemons.AsQueryable();
        var result = 
            await data.AsNoTracking()
            .Where(
                x=> x.IsDelete == false
                && x.IsActive == true)
            .FirstOrDefaultAsync(x=> x.Id == id);
        return result;
    }

    public async Task<Pokemon> UpdateAsync(
        Guid id ,
        Pokemon pokemon)
    {
        var data = await GetAsync(id);
        if(data != null)
        {
            data.Weight = pokemon.Weight;
            data.Height = pokemon.Height;
            data.ImageFile = pokemon.ImageFile;
            data.PokemonImage = pokemon.PokemonImage;
            data.PokemonName = pokemon.PokemonName;
            data.PokemonType = pokemon.PokemonType;
        }
        _context.Pokemons.Update(data);
        _context.SaveChanges();
        return data;
    }
}
