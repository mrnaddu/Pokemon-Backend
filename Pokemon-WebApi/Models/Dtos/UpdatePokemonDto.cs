using Pokemon_WebApi.Models.Enums;

namespace Pokemon_WebApi.Models.Dtos;

public class UpdatePokemonDto
{
    public string PokemonName { get; set; }
    public PokemonTypes PokemonType { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public IFormFile ImageFile { get; set; }
}
