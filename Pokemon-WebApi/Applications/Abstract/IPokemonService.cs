using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Response;

namespace Pokemon_WebApi.Applications.Abstract;

public interface IPokemonService
{
    Task<ResponseValue<PokemonDto>> CreatePokemonAsync(
        CreateUpdatePokemonDto pokemon);
    Task<ResponseValue<PokemonDto>> DeletePokemonAsync(
        Guid id);
    Task<ResponseValue<PokemonDto>> UpdatePokemonAsync(
        Guid id ,
        CreateUpdatePokemonDto pokemon);
    Task<ResponseValue<List<PokemonDto>>> GetAllPokemonAsync();
    Task<ResponseValue<PokemonDto>> GetByIdPokemonAsync(
        Guid id);
}
