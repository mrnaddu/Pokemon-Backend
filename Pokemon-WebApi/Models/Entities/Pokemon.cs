using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pokemon_WebApi.Models.Entities;

public class Pokemon
{
    public Guid Id { get; set; }
    [Required]
    public string? PokemonName { get; set; }
    public string? PokemonImage { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }
}
