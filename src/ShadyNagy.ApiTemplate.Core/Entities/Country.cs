using System.Collections.Generic;
using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;

public class Country : BaseEntity<string>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public virtual List<City> Cities { get; set; } = new List<City>();

  public void AddCity(City city)
  {
    Cities.Add(city);
  }
}

