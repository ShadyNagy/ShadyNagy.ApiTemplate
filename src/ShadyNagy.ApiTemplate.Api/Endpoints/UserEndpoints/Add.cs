using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.UserEndpoints;

public class Add : BaseAsyncEndpoint
    .WithRequest<UserDto>
    .WithResponse<UserDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<User> _readRepository;
  private readonly IRepository<User> _repository;

  public Add(IMapper mapper, IReadRepository<User> readRepository, IRepository<User> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  [HttpPost("/users")]
  [SwaggerOperation(
      Summary = "Adds a User",
      Description = "Adds a User",
      OperationId = "User.Add",
      Tags = new[] { "UsersEndpoints" })
  ]
  public override async Task<ActionResult<UserDto>> HandleAsync([FromBody] UserDto user, CancellationToken cancellationToken)
  {
    var entityToSave = _mapper.Map<User>(User);
    var maxId = await _readRepository.GetMaxIdAsync();

    var addedEntity = await _repository.AddAsync(entityToSave);

    return Ok(addedEntity);
  }
}
