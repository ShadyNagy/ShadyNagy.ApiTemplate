using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

[Authorize]
public class Delete : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<bool>
{
  private readonly IRepository<Branch> _repository;

  public Delete(IRepository<Branch> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteBranchRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a branch",
      Description = "Deletes a branch",
      OperationId = "Branch.Delete",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<bool>> HandleAsync(int id, CancellationToken cancellationToken = default)
  {
    var spec = new BranchByIdSpec(id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    await _repository.DeleteAsync(entity, cancellationToken);

    return Ok(true);
  }
}
