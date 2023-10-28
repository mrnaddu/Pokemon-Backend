using Microsoft.AspNetCore.Mvc;
using Pokemon_WebApi.Models.Entities;

namespace Pokemon_WebApi.Controllers.Abastract;

public interface IPokemonController
{
    IActionResult Add([FromForm] Pokemon pokemon);
}
