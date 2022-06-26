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

public class Edit : BaseAsyncEndpoint
    .WithRequest<CityDto>
    .WithResponse<CityDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<City> _readRepository;
  private readonly IRepository<City> _repository;

  public Edit(IMapper mapper, IReadRepository<City> readRepository, IRepository<City> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  [HttpPut("/cities/{id:int}")]
  [SwaggerOperation(
      Summary = "Edits a City",
      Description = "Edits a City",
      OperationId = "City.Edit",
      Tags = new[] { "CitiesEndpoints" })
  ]
  public override async Task<ActionResult<CityDto>> HandleAsync([FromBody] CityDto City, CancellationToken cancellationToken)
  {
    var spec = new CityByIdSpec(City.Id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    var entityToSave = _mapper.Map<City>(City);
    await _repository.UpdateAsync(entityToSave);

    return Ok(entityToSave);
  }
}
