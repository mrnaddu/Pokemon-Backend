using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Models.Response;

namespace Pokemon_WebApi.Repository.Abastract;

public interface IPokemonRepository
{
    bool Add(Pokemon model);
}
