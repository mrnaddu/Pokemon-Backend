using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Models.Response;

namespace Pokemon_WebApi.Repository.Abastract;

public interface IPokemonRepository
{
    Task AddPokemonAsync(Pokemon pokemon);
    Task<Pokemon> GetPokemonByIdAsync(Guid id);
    Task DeletePokemonByIdAsync(Guid id);
    Task<List<Pokemon>> GetAllPokemonAsync();
    Task<Pokemon> UpdatePokemonAsync(Guid id, Pokemon pokemon);
}
