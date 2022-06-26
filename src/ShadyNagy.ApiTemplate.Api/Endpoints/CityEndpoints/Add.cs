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

public class Add : BaseAsyncEndpoint
    .WithRequest<CityDto>
    .WithResponse<CityDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<City> _readRepository;
  private readonly IRepository<City> _repository;

  public Add(IMapper mapper, IReadRepository<City> readRepository, IRepository<City> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  [HttpPost("/cities")]
  [SwaggerOperation(
      Summary = "Adds a City",
      Description = "Adds a City",
      OperationId = "City.Add",
      Tags = new[] { "CitiesEndpoints" })
  ]
  public override async Task<ActionResult<CityDto>> HandleAsync([FromBody] CityDto City, CancellationToken cancellationToken)
  {
    var entityToSave = _mapper.Map<City>(City);
    var maxId = await _readRepository.GetMaxIdAsync();

    var addedEntity = await _repository.AddAsync(entityToSave);

    return Ok(addedEntity);
  }
}
