using Pokemon_WebApi.Models.Common;
using Pokemon_WebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pokemon_WebApi.Models.Entities;

public class Pokemon : Entity
{
    [Required]
    [AllowNull]
    public string PokemonName { get; set; } = string.Empty;

    [AllowNull]
    public string PokemonImage { get; set; }

    [Required]
    public PokemonTypes PokemonType { get; set; }

    [Required]
    public double Height { get; set; } = 10.00;
    [Required]
    public double Weight { get; set; } = 10.00;

    public bool IsDelete { get; set; } = false;

    [NotMapped]
    [AllowNull]
    public IFormFile ImageFile { get; set; }

    public Pokemon(Guid id)
    : base(id) => Id = id;
    protected Pokemon()
    {

    }

}
