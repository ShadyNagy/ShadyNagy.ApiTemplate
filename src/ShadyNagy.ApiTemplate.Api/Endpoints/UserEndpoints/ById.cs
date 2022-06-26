﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.UserEndpoints;

public class ById : BaseAsyncEndpoint
    .WithRequest<Guid>
    .WithResponse<UserDto>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<User> _repository;

  public ById(IMapper mapper, IReadRepository<User> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet("/users/{id}")]
  [SwaggerOperation(
      Summary = "Gets User by id",
      Description = "Gets User by id",
      OperationId = "User.ById",
      Tags = new[] { "UsersEndpoints" })
  ]
  public override async Task<ActionResult<UserDto>> HandleAsync(Guid id, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(id);
    var response = _mapper.Map<UserDto>(entity);

    return Ok(response);
  }
}
