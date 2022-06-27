using System.Collections.Generic;
using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;
public class Branch : BaseEntity<int>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;
  public string? Phone { get; set; }
  public string? Email { get; set; }
  public int CityId { get; set; }
  public virtual City? City { get; set; }
}
