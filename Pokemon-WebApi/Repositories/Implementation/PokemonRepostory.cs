using Pokemon_WebApi.Context;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Repository.Abastract;

namespace Pokemon_WebApi.Repository.Implementation;

public class PokemonRepostory : IPokemonRepository
{
    private readonly PokemonContext _context;
    private readonly ILogger<PokemonRepostory> _logger;
    public PokemonRepostory(
        PokemonContext context,
        ILogger<PokemonRepostory> logger)
    {
        _context = context;
        _logger = logger;
    }
    public bool Add(Pokemon model)
    {
        try
        {
            _context.Pokemons.Add(model);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("There is problem while saving POKEMON ", ex);
            return false;
        }
    }
}
