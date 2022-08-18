using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;

public class Filter : EndpointBaseAsync
    .WithRequest<CountryFilterDto>
    .WithActionResult<ListResponse<CountryDto>>
{
  private readonly ICountryUiService _countryUiService;

  public Filter(ICountryUiService countryUiService)
  {
    _countryUiService = countryUiService;
  }

  [HttpPost(FilterCountryRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a filter of all Countries",
      Description = "Gets a filter of Countries",
      OperationId = "Countries.Filter",
      Tags = new[] { "CountriesEndpoints" })
  ]
  public override async Task<ActionResult<ListResponse<CountryDto>>> HandleAsync([FromBody] CountryFilterDto filter, CancellationToken cancellationToken = default)
  {
    return Ok(await _countryUiService.GetCountriesByFilterAsync(filter));
  }
}
