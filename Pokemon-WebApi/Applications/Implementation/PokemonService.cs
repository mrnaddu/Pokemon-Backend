using Pokemon_WebApi.Applications.Abstract;
using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Response;

namespace Pokemon_WebApi.Applications.Implementation;

public class PokemonService : IPokemonService
{
    public Task<ResponseValue<PokemonDto>> CreatePokemonAsync(
        CreateUpdatePokemonDto pokemon)
    {
        throw new NotImplementedException();
    }
}
