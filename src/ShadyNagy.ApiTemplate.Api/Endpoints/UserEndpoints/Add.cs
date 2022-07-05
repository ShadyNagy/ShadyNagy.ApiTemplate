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

  [HttpPost(AddUserRequest.Route)]
  [SwaggerOperation(
      Summary = "Adds a User",
      Description = "Adds a User",
      OperationId = "User.Add",
      Tags = new[] { "UsersEndpoints" })
  ]
  public override async Task<ActionResult<UserDto>> HandleAsync([FromBody] UserDto userDto, CancellationToken cancellationToken = default)
  {
    var entityToSave = _mapper.Map<User>(userDto);

    var addedEntity = await _repository.AddAsync(entityToSave, cancellationToken);

    return Ok(addedEntity);
  }
}
