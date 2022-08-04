using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;

public class Delete : EndpointBaseAsync
    .WithRequest<string>
    .WithActionResult<bool>
{
  private readonly IRepository<Country> _repository;

  public Delete(IRepository<Country> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteCountryRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a Country",
      Description = "Deletes a Country",
      OperationId = "Country.Delete",
      Tags = new[] { "CountriesEndpoints" })
  ]
  public override async Task<ActionResult<bool>> HandleAsync(string id, CancellationToken cancellationToken = default)
  {
    var spec = new CountryByIdSpec(id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    await _repository.DeleteAsync(entity, cancellationToken);

    return Ok(true);
  }
}
