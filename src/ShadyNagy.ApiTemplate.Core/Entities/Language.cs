using System.Collections.Generic;
using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;

public class Language : BaseEntity<string>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public virtual List<CityTranslation> CityTranslations { get; set; } = new List<CityTranslation>();
}
