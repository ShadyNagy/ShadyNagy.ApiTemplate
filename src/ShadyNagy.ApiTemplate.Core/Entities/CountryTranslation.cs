using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;

public class CountryTranslation : BaseEntity<int>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public string CountryId { get; set; }
  public string LanguageId { get; set; } = "en";
  public virtual Country? Country { get; set; }
  public virtual Language? Language { get; set; }
}
