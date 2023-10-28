using Microsoft.AspNetCore.Mvc;
using Pokemon_WebApi.Models.Dtos;

namespace Pokemon_WebApi.Controllers.Abastract;

public interface IPokemonController
{
    Task<IActionResult> CreatePokemonAsync(
        CreatePokemonDto pokemon);
    Task<IActionResult> UpdatePokemonAsync(
        UpdatePokemonDto pokemon,
        Guid id);
    Task<IActionResult> DeletePokemonAsync(
        Guid id);
    Task<IActionResult> GetPokemonByIdAsync(
        Guid id);
    Task<IActionResult> GetAllPokemonAsync();
}
