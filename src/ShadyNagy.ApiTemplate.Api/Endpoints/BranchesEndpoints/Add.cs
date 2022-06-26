using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchesEndpoints;

public class Add : BaseAsyncEndpoint
    .WithRequest<BranchDto>
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

  [HttpPut("/branches")]
  [SwaggerOperation(
      Summary = "Adds a branch",
      Description = "Adds a branch",
      OperationId = "Branch.Add",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<BranchDto>> HandleAsync([FromBody] BranchDto branch, CancellationToken cancellationToken)
  {
    var entityToSave = _mapper.Map<Branch>(branch);
    var maxId = await _readRepository.GetMaxIdAsync();

    var addedEntity = await _repository.AddAsync(entityToSave);

    return Ok(addedEntity);
  }
}
