using System.Collections.Generic;
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

public class List : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<ListResponse<BranchDto>>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Branch> _repository;

  public List(IMapper mapper, IReadRepository<Branch> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(ListBranchRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a list of all branches",
      Description = "Gets a list of branches",
      OperationId = "Branches.List",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<ListResponse<BranchDto>>> HandleAsync(CancellationToken cancellationToken)
  {
    var spec = new BranchesOrderByNameSpec();
    var entities = await _repository.ListAsync(spec);
    var responseData = _mapper.Map<List<BranchDto>>(entities);
    var response = new ListResponse<BranchDto>(responseData);

    return Ok(response);
  }
}
