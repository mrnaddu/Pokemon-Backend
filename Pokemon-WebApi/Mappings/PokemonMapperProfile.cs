using AutoMapper;
using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Entities;
using System.Text.Json;

namespace Pokemon_WebApi.Mapping;

public class PokemonMapperProfile : Profile
{
    public PokemonMapperProfile()
    {
        CreateMap<Pokemon, PokemonDto>()
            .ForMember(dest => dest.Stats, opt => opt.MapFrom(src => ConvertJsonToString(src.Stats))).ReverseMap();
        CreateMap<CreatePokemonDto, Pokemon>()
            .ForMember(dest => dest.Stats, opt => opt.MapFrom(src => ConvertStringToJson(src.Stats))).ReverseMap();
        CreateMap<UpdatePokemonDto, Pokemon>()
            .ForMember(dest => dest.Stats, opt => opt.MapFrom(src => ConvertStringToJson(src.Stats))).ReverseMap();
    }

    public static string ConvertJsonToString(JsonElement? jsonElement)
    {
        var jsonString = string.Empty;
        if (jsonElement.HasValue)
            jsonString = jsonElement.Value.GetRawText();
        return jsonString;
    }

    public static JsonElement ConvertStringToJson(string dataStr)
    {
        return JsonDocument.Parse(dataStr).RootElement;
    }
}
