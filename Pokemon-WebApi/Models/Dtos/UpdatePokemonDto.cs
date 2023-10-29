using Pokemon_WebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Pokemon_WebApi.Models.Dtos;

public class UpdatePokemonDto
{
    [AllowNull]
    public string PokemonName { get; set; }
    [Required]
    public PokemonTypes PokemonType { get; set; }
    [Required]
    public PokemonGenders PokemonGender { get; set; }
    [Required]
    public double Height { get; set; }
    [Required]
    public double Weight { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Abilities { get; set; }
    [Required]
    public string Stats { get; set; }
    [AllowNull]
    public IFormFile ImageFile { get; set; }
}
