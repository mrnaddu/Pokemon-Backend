using Microsoft.AspNetCore.Mvc;
using Pokemon_WebApi.Controllers.Abastract;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Models.Response;
using Pokemon_WebApi.Repository.Abastract;

namespace Pokemon_WebApi.Controllers.Implementation;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase, IPokemonController
{
    private readonly IFileService _fileService;
    private readonly IPokemonRepository _pokemonRepo;
    public PokemonController(
        IFileService fileService,
        IPokemonRepository pokemonRepo)
    {
        _fileService = fileService;
        _pokemonRepo = pokemonRepo; 
    }

    [HttpPost]
    public IActionResult Add([FromForm] Pokemon pokemon)
    {
        var response = new ResponseValue();
        if (!ModelState.IsValid)
        {
            response.StatusCode = 0;
            response.Message = "Please pass the valid data";
            return Ok(response);
        }
        if (pokemon.ImageFile != null)
        {
            var fileResult = _fileService.SaveImage(pokemon.ImageFile);
            if (fileResult.Item1 == 1)
            {
                pokemon.PokemonImage = fileResult.Item2; // getting name of image
            }
            var productResult = _pokemonRepo.Add(pokemon);
            if (productResult)
            {
                response.StatusCode = 1;
                response.Message = "Added successfully";
            }
            else
            {
                response.StatusCode = 0;
                response.Message = "Error on adding product";
            }
        }
        return Ok(response);
    }
}
