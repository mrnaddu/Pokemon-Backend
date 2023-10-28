﻿using Pokemon_WebApi.Models.Common;

namespace Pokemon_WebApi.Models.Dtos;

public class PokemonDto : EntityDto
{
    public string PokemonName { get; set; }
    public string PokemonImage { get; set; }
}