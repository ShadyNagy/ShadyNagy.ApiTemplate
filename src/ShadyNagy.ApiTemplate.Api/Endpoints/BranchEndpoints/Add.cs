using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

[Authorize]
public class Add : EndpointBaseAsync
    .WithRequest<AddBranchRequest>
    .WithActionResult<BranchDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Branch> _readRepository;
  private readonly IRepository<Branch> _repository;

  public Add(IMapper mapper, IReadRepository<Branch> readRepository, IRepository<Branch> repository)
  {
    _mapper = mapper;
    _readRepository = readRepository;
    _repository = repository;
  }

  [HttpPost(AddBranchRequest.Route)]
  [SwaggerOperation(
      Summary = "Adds a branch",
      Description = "Adds a branch",
      OperationId = "Branch.Add",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<BranchDto>> HandleAsync([FromBody] AddBranchRequest branchDto, CancellationToken cancellationToken = default)
  {
    var entityToSave = _mapper.Map<Branch>(branchDto);

    var addedEntity = await _repository.AddAsync(entityToSave, cancellationToken);

    var response = _mapper.Map<BranchDto>(addedEntity);

    return Ok(response);
  }
}
