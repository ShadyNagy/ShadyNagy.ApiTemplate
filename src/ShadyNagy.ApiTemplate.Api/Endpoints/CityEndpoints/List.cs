using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<ListResponse<CityDto>>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<City> _repository;

  public List(IMapper mapper, IReadRepository<City> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(ListCityRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a list of all Cities",
      Description = "Gets a list of Cities",
      OperationId = "Cities.List",
      Tags = new[] { "CitiesEndpoints" })
  ]
  public override async Task<ActionResult<ListResponse<CityDto>>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var spec = new CitiesOrderByNameSpec();
    var entities = await _repository.ListAsync(spec, cancellationToken);
    var responseData = _mapper.Map<List<CityDto>>(entities);
    var response = new ListResponse<CityDto>(responseData);

    return Ok(response);
  }
}
