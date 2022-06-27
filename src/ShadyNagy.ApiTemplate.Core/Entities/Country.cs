using System.Collections.Generic;
using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;

public class Country : BaseEntity<string>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public virtual List<City>? Cities { get; set; }

  public void AddCity(City city)
  {
    if (Cities == null)
    {
      Cities = new List<City>();
    }
    Cities.Add(city);
  }
}

