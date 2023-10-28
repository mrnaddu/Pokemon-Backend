using Microsoft.AspNetCore.Mvc;
using Pokemon_WebApi.Applications.Abstract;
using Pokemon_WebApi.Controllers.Abastract;
using Pokemon_WebApi.Models.Dtos;

namespace Pokemon_WebApi.Controllers.Implementation;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase, IPokemonController
{
    private readonly IPokemonService _service;
    public PokemonController(
        IPokemonService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePokemonAsync(
        [FromForm] CreatePokemonDto pokemon)
    {
        var result = await _service.CreatePokemonAsync(pokemon);
        if (result != null)
            return Ok(result);

        else return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePokemonAsync(
        Guid id)
    {
        var result = await _service.DeletePokemonAsync(id);
        if (result != null)
            return Ok(result);

        else return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPokemonAsync()
    {
        var result = await _service.GetAllPokemonAsync();
        if (result != null)
            return Ok(result);

        else return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPokemonByIdAsync(
        Guid id)
    {
        var result = await _service.GetByIdPokemonAsync(id);
        if (result != null)
            return Ok(result);

        else return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePokemonAsync(
        [FromForm] UpdatePokemonDto pokemon,
        Guid id)
    {
        var result = await _service.UpdatePokemonAsync(
            id,
            pokemon);
        if (result != null)
            return Ok(result);

        else return BadRequest();
    }
}
