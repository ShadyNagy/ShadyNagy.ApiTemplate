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

public class Add : EndpointBaseAsync
    .WithRequest<AddCountryRequest>
    .WithActionResult<CountryDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Country> _readRepository;
  private readonly IRepository<Country> _repository;

  public Add(IMapper mapper, IReadRepository<Country> readRepository, IRepository<Country> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  [HttpPost(AddCountryRequest.Route)]
  [SwaggerOperation(
      Summary = "Adds a Country",
      Description = "Adds a Country",
      OperationId = "Country.Add",
      Tags = new[] { "CountriesEndpoints" })
  ]
  public override async Task<ActionResult<CountryDto>> HandleAsync([FromBody] AddCountryRequest countryDto, CancellationToken cancellationToken = default)
  {
    var entityToSave = _mapper.Map<Country>(countryDto);

    var addedEntity = await _repository.AddAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<CountryDto>(addedEntity);

    return Ok(response);
  }
}
