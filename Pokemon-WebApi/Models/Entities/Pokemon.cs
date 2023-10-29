using Pokemon_WebApi.Models.Common;
using Pokemon_WebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Pokemon_WebApi.Models.Entities;

public class Pokemon : Entity
{
    [Required]
    public string PokemonName { get; set; } = string.Empty;
    public string PokemonImage { get; set; } = string.Empty;
    [Required]
    public PokemonTypes PokemonType { get; set; }
    [Required]
    public PokemonGenders PokemonGender { get; set; }
    [Required]
    public double Height { get; set; } = 10.00;
    [Required]
    public double Weight { get; set; } = 10.00;
    public bool IsDelete { get; set; } = false;
    public bool IsActive { get; set; } = false;
    [Required]
    public string Category {  get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string Abilities { get; set; } = string.Empty;

    [Required]
    public JsonElement Stats { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; }

    public Pokemon(Guid id)
    : base(id) => Id = id;
    protected Pokemon()
    {

    }
}
