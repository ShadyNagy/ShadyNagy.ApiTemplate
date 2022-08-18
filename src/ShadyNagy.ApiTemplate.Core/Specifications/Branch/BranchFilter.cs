namespace ShadyNagy.ApiTemplate.Core.Specifications;

public class BranchFilter : BaseFilter
{
  public int? Id { get; set; }
  public int? CityId { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;
}
