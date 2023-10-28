using Pokemon_WebApi.Models.Entities;

namespace Pokemon_WebApi.Repository.Abastract;

public interface IPokemonRepository
{
    bool Add(Pokemon model);
}
