using Microsoft.EntityFrameworkCore;
using Pokemon_WebApi.Context;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Repository.Abastract;

namespace Pokemon_WebApi.Repository.Implementation;

public class PokemonRepostory : IPokemonRepository
{
    private readonly PokemonContext _context;
    public PokemonRepostory(
        PokemonContext context)
    {
        _context = context;
    }
    public async Task AddPokemonAsync(
        Pokemon pokemon)
    {
        try
        {
            await _context.Pokemons.AddAsync(pokemon);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }     
    }

    public async Task DeletePokemonByIdAsync(
        Guid id)
    {
        try
        {
            var data = await GetPokemonByIdAsync(id);
            if (true)
            {
                _context.Pokemons.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }      
    }

    public async Task<List<Pokemon>> GetAllPokemonAsync()
    {
        try
        {
            var data = await _context.Pokemons.ToListAsync();
            return data;
        }
        catch(Exception ex )
        {
            Console.WriteLine(ex.Message);
            return null;
        }     
    }

    public async Task<Pokemon> GetPokemonByIdAsync(
        Guid id)
    {
        try
        {
            var data = await _context.Pokemons.FirstOrDefaultAsync(
                x => x.Id == id);
            if(data == null)
                return null;
            else
                return data;
        }
        catch(Exception ex )
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<Pokemon> UpdatePokemonAsync(
        Guid id,
        Pokemon pokemon)
    {
        try
        {
            var data = await GetPokemonByIdAsync(id);
            data.PokemonName = pokemon.PokemonName;
            await _context.SaveChangesAsync();
            return data;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
