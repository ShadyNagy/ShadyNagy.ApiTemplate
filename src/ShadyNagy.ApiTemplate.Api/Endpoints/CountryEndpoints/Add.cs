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

public class Add : BaseAsyncEndpoint
    .WithRequest<CountryDto>
    .WithResponse<CountryDto>
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

  [HttpPost("/countries")]
  [SwaggerOperation(
      Summary = "Adds a Country",
      Description = "Adds a Country",
      OperationId = "Country.Add",
      Tags = new[] { "CountriesEndpoints" })
  ]
  public override async Task<ActionResult<CountryDto>> HandleAsync([FromBody] CountryDto Country, CancellationToken cancellationToken)
  {
    var entityToSave = _mapper.Map<Country>(Country);
    var maxId = await _readRepository.GetMaxIdAsync();

    var addedEntity = await _repository.AddAsync(entityToSave);

    return Ok(addedEntity);
  }
}
