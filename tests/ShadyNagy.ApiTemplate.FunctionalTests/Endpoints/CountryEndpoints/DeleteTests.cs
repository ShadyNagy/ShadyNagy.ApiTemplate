using System.Net.Http;
using System.Threading.Tasks;
using Ardalis.HttpClientTestExtensions;
using ShadyNagy.ApiTemplate.Api;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;
using ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;
using ShadyNagy.ApiTemplate.TestsSharedKernel;
using Shouldly;
using Xunit;

namespace ShadyNagy.ApiTemplate.FunctionalTests.Endpoints.CountryEndpoints;

[Collection("Sequential")]
public class DeleteTests : IClassFixture<CustomWebApplicationFactory<ApiMarker>>
{
  private readonly HttpClient _client;

  public DeleteTests(CustomWebApplicationFactory<ApiMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsTrueAfterDeleteAsync()
  {
    var response = await _client.DeleteAsync(DeleteCountryRequest.BuildRoute("EG"));

    response.IsSuccessStatusCode.ShouldBeTrue();
  }
}

