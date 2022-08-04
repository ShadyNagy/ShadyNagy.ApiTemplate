using System.Collections.Generic;
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
public class ByCityId : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<ListResponse<BranchDto>>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Branch> _repository;

  public ByCityId(IMapper mapper, IReadRepository<Branch> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(ByCityIdBranchRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets branches by city id",
      Description = "Gets branches by city id",
      OperationId = "Branches.ByCityId",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<ListResponse<BranchDto>>> HandleAsync(int cityId, CancellationToken cancellationToken = default)
  {
    var spec = new BranchesByCityIdSpec(cityId);
    var entities = await _repository.ListAsync(spec, cancellationToken);
    var responseData = _mapper.Map<List<BranchDto>>(entities);
    var response = new ListResponse<BranchDto>(responseData);

    return Ok(response);
  }
}
