using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;

public class AddCityRequest
{
  public const string Route = "/cities";

  [Required]
  public string Name { get; set; } = string.Empty;
  public string? CountryId { get; set; }
}
