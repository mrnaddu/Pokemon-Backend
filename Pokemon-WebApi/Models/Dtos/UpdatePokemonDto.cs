using Pokemon_WebApi.Models.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Pokemon_WebApi.Models.Dtos;

public class UpdatePokemonDto
{
    [AllowNull]
    public string PokemonName { get; set; }
    [AllowNull]
    public PokemonTypes PokemonType { get; set; }
    [AllowNull]
    public double Height { get; set; }
    [AllowNull]
    public double Weight { get; set; }
    [AllowNull]
    public IFormFile ImageFile { get; set; }
}
