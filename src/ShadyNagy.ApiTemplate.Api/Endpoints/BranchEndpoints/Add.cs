using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

public class Add : BaseAsyncEndpoint
    .WithRequest<AddBranchRequest>
    .WithResponse<BranchDto>
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
  public override async Task<ActionResult<BranchDto>> HandleAsync([FromBody] AddBranchRequest branch, CancellationToken cancellationToken)
  {
    var entityToSave = _mapper.Map<Branch>(branch);

    var addedEntity = await _repository.AddAsync(entityToSave);

    return Ok(addedEntity);
  }
}
