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

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;

public class List : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<ListResponse<CountryDto>>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Country> _repository;

  public List(IMapper mapper, IReadRepository<Country> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(ListCountryRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a list of all Countries",
      Description = "Gets a list of Countries",
      OperationId = "Countries.List",
      Tags = new[] { "CountriesEndpoints" })
  ]
  public override async Task<ActionResult<ListResponse<CountryDto>>> HandleAsync(CancellationToken cancellationToken)
  {
    var spec = new CountriesOrderByNameSpec();
    var entities = await _repository.ListAsync(spec);
    var responseData = _mapper.Map<List<CountryDto>>(entities);
    var response = new ListResponse<CountryDto>(responseData);

    return Ok(response);
  }
}
