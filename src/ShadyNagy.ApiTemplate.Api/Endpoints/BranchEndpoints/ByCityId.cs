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

public class ByCityId : BaseAsyncEndpoint
    .WithRequest<int>
    .WithResponse<ListResponse<BranchDto>>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Branch> _repository;

  public ByCityId(IMapper mapper, IReadRepository<Branch> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet("/branches/by-city-id/{cityId:int}")]
  [SwaggerOperation(
      Summary = "Gets branches by city id",
      Description = "Gets branches by city id",
      OperationId = "Branches.ByCityId",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<ListResponse<BranchDto>>> HandleAsync(int cityId, CancellationToken cancellationToken)
  {
    var spec = new BranchesByCityIdSpec(cityId);
    var entities = await _repository.ListAsync(spec);
    var responseData = _mapper.Map<List<BranchDto>>(entities);
    var response = new ListResponse<BranchDto>(responseData);

    return Ok(response);
  }
}
