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
public class EditTests : IClassFixture<CustomWebApplicationFactory<ApiMarker>>
{
  private readonly HttpClient _client;

  public EditTests(CustomWebApplicationFactory<ApiMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedCityAfterEditAsync()
  {
    var enitiyToEdit = new CityDto
    {
      Id = 1,
      CountryId = "EG",
      Name = "Alexandria"
    };
    string jsonString = JsonSerializer.Serialize(enitiyToEdit);
    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

    var response = await _client.PutAsync(EditCityRequest.Route, content);
    response.IsSuccessStatusCode.ShouldBeTrue();

    var contents = await response.Content.ReadAsStringAsync();

    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };
    var entityResponse = JsonSerializer.Deserialize<CityDto>(contents, options);

    entityResponse?.Name.ShouldBe(enitiyToEdit.Name);
    entityResponse?.CountryId.ShouldBe(enitiyToEdit.CountryId);
  }
}

