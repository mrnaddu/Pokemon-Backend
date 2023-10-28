using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Response;

namespace Pokemon_WebApi.Applications.Abstract;

public interface IPokemonService
{
    Task<ResponseValue<PokemonDto>> CreatePokemonAsync(CreateUpdatePokemonDto pokemon);
}
