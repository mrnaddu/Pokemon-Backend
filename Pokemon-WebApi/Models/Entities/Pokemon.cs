using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Pokemon_WebApi.Models.Entities;

public class Pokemon
{
    [Key]
    public Guid Id { get; set; }
    [Required]

    [AllowNull]
    public string PokemonName { get; set; }

    [AllowNull]
    public string PokemonImage { get; set; }

    [NotMapped]
    [AllowNull]
    public IFormFile ImageFile { get; set; }
}
