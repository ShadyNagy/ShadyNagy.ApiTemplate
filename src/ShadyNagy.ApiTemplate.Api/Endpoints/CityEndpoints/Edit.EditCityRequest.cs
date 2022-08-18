using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ShadyNagy.ApiTemplate.Api.Dtos;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;

public class EditCityRequest
{
  public const string Route = "/cities";

  [Required]
  public int Id { get; set; }
  [Required]
  public string? CountryId { get; set; }
  public List<CityTranslationDto> CityTranslations { get; set; } = new List<CityTranslationDto>();
}
