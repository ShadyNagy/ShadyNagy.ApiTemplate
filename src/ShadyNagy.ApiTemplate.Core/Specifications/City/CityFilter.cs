namespace ShadyNagy.ApiTemplate.Core.Specifications;

public class CityFilter : BaseFilter
{
  public int? Id { get; set; }
  public string Name { get; set; } = string.Empty;
}
