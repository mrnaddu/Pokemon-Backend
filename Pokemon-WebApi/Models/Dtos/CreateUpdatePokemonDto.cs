using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Pokemon_WebApi.Models.Dtos;

public class CreateUpdatePokemonDto
{
    [Required]
    [AllowNull]
    public string PokemonName { get; set; }
    [AllowNull]
    public string PokemonImage { get; set; }
    [AllowNull]
    public IFormFile ImageFile { get; set; }
}
