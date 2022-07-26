using System.Collections.Generic;
using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;

public class City : BaseEntity<int>, IAggregateRoot
{
  public string Name { get; set; } = string.Empty;
  public string? CountryId { get; set; }
  public virtual Country? Country { get; set; }
  public virtual List<Branch> Branches { get; set; } = new List<Branch>();
  public virtual List<UserInfo> UserInfos { get; set; } = new List<UserInfo>();
}
