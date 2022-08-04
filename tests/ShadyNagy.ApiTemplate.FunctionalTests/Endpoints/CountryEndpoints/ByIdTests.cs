using System.Net.Http;
using System.Threading.Tasks;
using Ardalis.HttpClientTestExtensions;
using ShadyNagy.ApiTemplate.Api;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;
using ShadyNagy.ApiTemplate.TestsSharedKernel;
using Shouldly;
using Xunit;

namespace ShadyNagy.ApiTemplate.FunctionalTests.Endpoints.CountryEndpoints;

[Collection("Sequential")]
public class ByIdTests : IClassFixture<CustomWebApplicationFactory<ApiMarker>>
{
  private readonly HttpClient _client;

  public ByIdTests(CustomWebApplicationFactory<ApiMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedCountryGivenId1Async()
  {
    var result = await _client.GetAndDeserializeAsync<CountryDto>(ByIdCountryRequest.BuildRoute("EG"));

    result.Id.ShouldBe("EG");
    result.Name.ShouldBe(SeedData.TestCountry1.Name);
  }
}

