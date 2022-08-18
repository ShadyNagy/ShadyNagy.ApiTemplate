using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.ApiTemplate.Api.Dtos;

public class CityTranslationDto
{
  public int CityId { get; set; }
  public string LanguageId { get; set; } = "en";
  [Required]
  public string Name { get; set; } = string.Empty;
}
