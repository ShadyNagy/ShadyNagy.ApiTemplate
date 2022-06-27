using System.Net.Http;
using System.Text;
using System.Text.Json;
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
public class AddTests : IClassFixture<CustomWebApplicationFactory<ApiMarker>>
{
  private readonly HttpClient _client;

  public AddTests(CustomWebApplicationFactory<ApiMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedCityAfterAddAsync()
  {
    var enitiyToAdd = new CityDto
    {
      Id = 2,
      CountryId = "EG",
      Name = "Alexandria"
    };
    string jsonString = JsonSerializer.Serialize(enitiyToAdd);
    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

    var response = await _client.PostAsync(AddCityRequest.Route, content);
    response.IsSuccessStatusCode.ShouldBeTrue();

    var contents = await response.Content.ReadAsStringAsync();

    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };
    var entityResponse = JsonSerializer.Deserialize<CityDto>(contents, options);

    entityResponse?.Name.ShouldBe(enitiyToAdd.Name);
    entityResponse?.CountryId.ShouldBe(enitiyToAdd.CountryId);
  }
}

