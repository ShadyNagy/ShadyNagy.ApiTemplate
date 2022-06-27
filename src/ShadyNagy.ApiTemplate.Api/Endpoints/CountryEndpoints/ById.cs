using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;

public class ById : BaseAsyncEndpoint
    .WithRequest<int>
    .WithResponse<CountryDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Country> _repository;

  public ById(IMapper mapper, IReadRepository<Country> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(ByIdCountryRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets Country by id",
      Description = "Gets Country by id",
      OperationId = "Country.ById",
      Tags = new[] { "CountriesEndpoints" })
  ]
  public override async Task<ActionResult<CountryDto>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(id);
    var response = _mapper.Map<CountryDto>(entity);

    return Ok(response);
  }
}
