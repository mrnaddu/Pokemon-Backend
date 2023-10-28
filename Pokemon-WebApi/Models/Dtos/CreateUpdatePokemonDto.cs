using Pokemon_WebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Pokemon_WebApi.Models.Dtos;

public class CreateUpdatePokemonDto
{
    [Required]
    [AllowNull]
    public string PokemonName { get; set; }

    [Required]
    public PokemonTypes PokemonType { get; set; }

    [Required]
    public double Height { get; set; }

    [Required]
    public double Weight { get; set; }

    [Required]
    [AllowNull]
    public IFormFile ImageFile { get; set; }
}
