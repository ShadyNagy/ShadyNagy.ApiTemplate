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
public class ListTests : IClassFixture<CustomWebApplicationFactory<ApiMarker>>
{
  private readonly HttpClient _client;

  public ListTests(CustomWebApplicationFactory<ApiMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedCountriesAsync()
  {
    var result = await _client.GetAndDeserializeAsync<ListResponse<CountryDto>>(ListCountryRequest.Route);

    result.Data.Count.ShouldBeGreaterThan(1);
    result.TotalCount.ShouldBe(2);
    result.Data[0].Name.ShouldBe(SeedData.TestCountry1.Name);
  }
}

