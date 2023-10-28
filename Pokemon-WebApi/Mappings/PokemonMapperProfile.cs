using AutoMapper;
using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Entities;

namespace Pokemon_WebApi.Mapping;

public class PokemonMapperProfile : Profile
{
    public PokemonMapperProfile()
    {
        CreateMap<Pokemon, PokemonDto>().ReverseMap();
        CreateMap<Pokemon, CreatePokemonDto>().ReverseMap();
        CreateMap<Pokemon, UpdatePokemonDto>().ReverseMap();
    }
}
