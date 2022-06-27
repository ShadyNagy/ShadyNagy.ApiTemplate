using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ShadyNagy.ApiTemplate.Api;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;
using ShadyNagy.ApiTemplate.TestsSharedKernel;
using Shouldly;
using Xunit;

namespace ShadyNagy.ApiTemplate.FunctionalTests.Endpoints.CountryEndpoints;

[Collection("Sequential")]
public class AddTests : IClassFixture<CustomWebApplicationFactory<ApiMarker>>
{
  private readonly HttpClient _client;

  public AddTests(CustomWebApplicationFactory<ApiMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedCountryAfterAddAsync()
  {
    var enitiyToAdd = new CountryDto
    {
      Id = "UAE",
      Name = "UAE"
    };
    string jsonString = JsonSerializer.Serialize(enitiyToAdd);
    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

    var response = await _client.PostAsync(AddCountryRequest.Route, content);
    response.IsSuccessStatusCode.ShouldBeTrue();

    var contents = await response.Content.ReadAsStringAsync();

    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };
    var entityResponse = JsonSerializer.Deserialize<CountryDto>(contents, options);

    entityResponse?.Name.ShouldBe(enitiyToAdd.Name);
  }
}

