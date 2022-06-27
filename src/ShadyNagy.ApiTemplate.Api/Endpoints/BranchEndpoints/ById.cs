﻿using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

public class ById : BaseAsyncEndpoint
    .WithRequest<int>
    .WithResponse<BranchDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Branch> _repository;

  public ById(IMapper mapper, IReadRepository<Branch> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(ByIdBranchRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets branch by id",
      Description = "Gets branch by id",
      OperationId = "Branch.ById",
      Tags = new[] { "BranchesEndpoints" })
  ]
  public override async Task<ActionResult<BranchDto>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(id);
    var response = _mapper.Map<BranchDto>(entity);

    return Ok(response);
  }
}
