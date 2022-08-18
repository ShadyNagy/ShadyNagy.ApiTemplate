using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;

public class CityTranslation : BaseEntity<int>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public int CityId { get; set; }
  public string LanguageId { get; set; } = "en";
  public virtual City? City { get; set; }
  public virtual Language? Language { get; set; }
}
