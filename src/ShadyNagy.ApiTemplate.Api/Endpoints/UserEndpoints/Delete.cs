using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.UserEndpoints;

public class Delete : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<bool>
{
  private readonly IRepository<User> _repository;

  public Delete(IRepository<User> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteUserRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a User",
      Description = "Deletes a User",
      OperationId = "User.Delete",
      Tags = new[] { "UsersEndpoints" })
  ]
  public override async Task<ActionResult<bool>> HandleAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var spec = new UserByIdSpec(id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    await _repository.DeleteAsync(entity);

    return Ok(true);
  }
}
