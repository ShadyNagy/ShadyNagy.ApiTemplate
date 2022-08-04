using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

[Authorize]
public class Edit : EndpointBaseAsync
    .WithRequest<EditBranchRequest>
    .WithActionResult<BranchDto>
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

  [HttpPut(EditBranchRequest.Route)]
  [SwaggerOperation(
      Summary = "Edits a branch",
      Description = "Edits a branch",
      OperationId = "Branch.Edit",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<BranchDto>> HandleAsync([FromBody] EditBranchRequest branchDto, CancellationToken cancellationToken = default)
  {
    var spec = new BranchByIdSpec(branchDto.Id);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    var entityToSave = _mapper.Map<Branch>(branchDto);
    await _repository.UpdateAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<BranchDto>(entityToSave);

    return Ok(response);
  }
}
