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

namespace ShadyNagy.ApiTemplate.Api.Endpoints.UserEndpoints;

public class Edit : EndpointBaseAsync
    .WithRequest<UserDto>
    .WithActionResult<UserDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<User> _readRepository;
  private readonly IRepository<User> _repository;

  public Edit(IMapper mapper, IReadRepository<User> readRepository, IRepository<User> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  [HttpPut(EditUserRequest.Route)]
  [SwaggerOperation(
      Summary = "Edits a User",
      Description = "Edits a User",
      OperationId = "User.Edit",
      Tags = new[] { "UsersEndpoints" })
  ]
  public override async Task<ActionResult<UserDto>> HandleAsync([FromBody] UserDto userDto, CancellationToken cancellationToken = default)
  {
    var spec = new UserByIdSpec(userDto.Id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    var entityToSave = _mapper.Map<User>(User);
    await _repository.UpdateAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<UserDto>(entityToSave);

    return Ok(response);
  }
}
