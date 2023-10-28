using Pokemon_WebApi.Models.Common;
using Pokemon_WebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pokemon_WebApi.Models.Entities;

public class Pokemon : AuditableWithBaseEntity<Guid>
{
    [Required]
    [AllowNull]
    public string PokemonName { get; set; }

    [AllowNull]
    public string PokemonImage { get; set; }

    [Required]
    public PokemonTypes PokemonType { get; set; }

    [Required]
    public double Height { get; set; }
    [Required]
    public double Weight { get; set; }

    [NotMapped]
    [AllowNull]
    public IFormFile ImageFile { get; set; }
}
