using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;

public class AddCountryRequest
{
  public const string Route = "/countries";

  [Required]
  public string Name { get; set; } = string.Empty;
}
