namespace ShadyNagy.ApiTemplate.Core.Specifications;

public class CountryFilter : BaseFilter
{
  public string? Id { get; set; }
  public string Name { get; set; } = string.Empty;
}
