using Pokemon_WebApi.Models.Enums;

namespace Pokemon_WebApi.Models.Dtos;

public class PokemonDto
{
    public Guid Id { get; set; }
    public string PokemonName { get; set; }
    public string PokemonImage { get; set; }
    public PokemonTypes PokemonType { get; set; }
    public PokemonGenders PokemonGender { get; set; }
    public bool IsDelete { get; set; }
    public bool IsActive { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Abilities { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Stats { get; set; }
}
