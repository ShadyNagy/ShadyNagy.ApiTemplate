using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;

public class Delete : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<bool>
{
  private readonly IRepository<City> _repository;

  public Delete(IRepository<City> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteCityRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a City",
      Description = "Deletes a City",
      OperationId = "City.Delete",
      Tags = new[] { "CitiesEndpoints" })
  ]
  public override async Task<ActionResult<bool>> HandleAsync(int id, CancellationToken cancellationToken = default)
  {
    var spec = new CityByIdSpec(id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    await _repository.DeleteAsync(entity, cancellationToken);

    return Ok(true);
  }
}
