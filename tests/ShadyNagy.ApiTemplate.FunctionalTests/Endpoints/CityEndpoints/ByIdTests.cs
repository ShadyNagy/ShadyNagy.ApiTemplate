using System.Net.Http;
using System.Threading.Tasks;
using Ardalis.HttpClientTestExtensions;
using ShadyNagy.ApiTemplate.Api;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;
using ShadyNagy.ApiTemplate.TestsSharedKernel;
using Shouldly;
using Xunit;

namespace ShadyNagy.ApiTemplate.FunctionalTests.Endpoints.CityEndpoints;

[Collection("Sequential")]
public class ByIdTests : IClassFixture<CustomWebApplicationFactory<ApiMarker>>
{
  private readonly HttpClient _client;

  public ByIdTests(CustomWebApplicationFactory<ApiMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedCityGivenId1Async()
  {
    var result = await _client.GetAndDeserializeAsync<CityDto>(ByIdCityRequest.BuildRoute(1));

    result.Id.ShouldBe(1);
    result.Name.ShouldBe(SeedData.TestCity1.Name);
  }
}

