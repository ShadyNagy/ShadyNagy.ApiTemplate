using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;

public class ById : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<CityDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<City> _repository;

  public ById(IMapper mapper, IReadRepository<City> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(ByIdCityRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets City by id",
      Description = "Gets City by id",
      OperationId = "City.ById",
      Tags = new[] { "CitiesEndpoints" })
  ]
  public override async Task<ActionResult<CityDto>> HandleAsync(int id, CancellationToken cancellationToken = default)
  {
    var entity = await _repository.GetByIdAsync(id, cancellationToken);
    var response = _mapper.Map<CityDto>(entity);

    return Ok(response);
  }
}
