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

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

public class Edit : BaseAsyncEndpoint
    .WithRequest<BranchDto>
    .WithResponse<BranchDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Branch> _readRepository;
  private readonly IRepository<Branch> _repository;

  public Edit(IMapper mapper, IReadRepository<Branch> readRepository, IRepository<Branch> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  [HttpPut("/branches/{id:int}")]
  [SwaggerOperation(
      Summary = "Edits a branch",
      Description = "Edits a branch",
      OperationId = "Branch.Edit",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<BranchDto>> HandleAsync([FromBody] BranchDto branch, CancellationToken cancellationToken)
  {
    var spec = new BranchByIdSpec(branch.Id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    var entityToSave = _mapper.Map<Branch>(branch);
    await _repository.UpdateAsync(entityToSave);

    return Ok(entityToSave);
  }
}
