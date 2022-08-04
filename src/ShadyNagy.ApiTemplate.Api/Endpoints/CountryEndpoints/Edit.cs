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

public class Edit : EndpointBaseAsync
    .WithRequest<EditCountryRequest>
    .WithActionResult<CountryDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Country> _readRepository;
  private readonly IRepository<Country> _repository;

  public Edit(IMapper mapper, IReadRepository<Country> readRepository, IRepository<Country> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  [HttpPut(EditCountryRequest.Route)]
  [SwaggerOperation(
      Summary = "Edits a Country",
      Description = "Edits a Country",
      OperationId = "Country.Edit",
      Tags = new[] { "CountriesEndpoints" })
  ]
  public override async Task<ActionResult<CountryDto>> HandleAsync([FromBody] EditCountryRequest countryDto, CancellationToken cancellationToken = default)
  {
    var spec = new CountryByIdSpec(countryDto.Id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    var entityToSave = _mapper.Map<Country>(countryDto);
    await _repository.UpdateAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<CountryDto>(entityToSave);

    return Ok(response);
  }
}
