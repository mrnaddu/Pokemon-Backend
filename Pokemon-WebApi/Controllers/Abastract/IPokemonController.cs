using Microsoft.AspNetCore.Mvc;
using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Entities;

namespace Pokemon_WebApi.Controllers.Abastract;

public interface IPokemonController
{
    Task<IActionResult> CreatePokemonAsync(
        CreateUpdatePokemonDto pokemon);
    Task<IActionResult> UpdatePokemonAsync(
        CreateUpdatePokemonDto pokemon,
        Guid id);
    Task<IActionResult> DeletePokemonAsync(
        Guid id);
    Task<IActionResult> GetPokemonByIdAsync(
        Guid id);
    Task<IActionResult> GetAllPokemonAsync();
}
