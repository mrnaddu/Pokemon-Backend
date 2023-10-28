using Pokemon_WebApi.Models.Common;
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

    [NotMapped]
    [AllowNull]
    public IFormFile ImageFile { get; set; }
}
