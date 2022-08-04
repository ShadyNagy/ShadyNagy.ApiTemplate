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

namespace ShadyNagy.ApiTemplate.Api.Endpoints.UserEndpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<ListResponse<UserDto>>
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<User> _repository;

  public List(IMapper mapper, IReadRepository<User> repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpGet(ListUserRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a list of all Users",
      Description = "Gets a list of Users",
      OperationId = "Users.List",
      Tags = new[] { "UsersEndpoints" })
  ]
  public override async Task<ActionResult<ListResponse<UserDto>>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var spec = new UsersOrderByNameSpec();
    var entities = await _repository.ListAsync(spec, cancellationToken);
    var responseData = _mapper.Map<List<UserDto>>(entities);
    var response = new ListResponse<UserDto>(responseData);

    return Ok(response);
  }
}
