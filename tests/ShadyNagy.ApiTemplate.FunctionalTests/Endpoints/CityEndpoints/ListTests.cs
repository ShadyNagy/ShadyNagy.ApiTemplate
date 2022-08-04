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
public class ListTests : IClassFixture<CustomWebApplicationFactory<ApiMarker>>
{
  private readonly HttpClient _client;

  public ListTests(CustomWebApplicationFactory<ApiMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedCitiesAsync()
  {
    var result = await _client.GetAndDeserializeAsync<ListResponse<CityDto>>(ListCityRequest.Route);

    result.Data.Count.ShouldBeGreaterThan(0);
    result.TotalCount.ShouldBe(1);
    result.Data[0].Name.ShouldBe(SeedData.TestCity1.Name);
  }
}

