using Pokemon_WebApi.Models.Entities;

namespace Pokemon_WebApi.Repositories.Abastract;

public interface IPokemonRepository
{
    Task<Pokemon> GetAsync(
        Guid id);
    Task<Pokemon> UpdateAsync(
        Guid id,
        Pokemon pokemon);
    Task<Pokemon> DeleteAsync(
        Guid id);
    Task<Pokemon> CreateAsync(
        Pokemon pokemon);
    Task<List<Pokemon>> GetAllAsync();
}
