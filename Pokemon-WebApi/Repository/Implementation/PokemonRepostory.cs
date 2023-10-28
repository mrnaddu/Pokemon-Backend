using Pokemon_WebApi.Context;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Repository.Abastract;

namespace Pokemon_WebApi.Repository.Implementation;

public class PokemonRepostory : IPokemonRepository
{
    private readonly PokemonContext _context;
    public PokemonRepostory(PokemonContext context)
    {
        this._context = context;
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

            return false;
        }
    }
}
