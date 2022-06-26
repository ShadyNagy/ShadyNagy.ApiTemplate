using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;
public class UserInfo : BaseEntity<int>, IAggregateRoot
{
  public string Address { get; set; } = string.Empty;
  public int CityId { get; set; }
  public virtual City City { get; set; } = new City();
  public virtual User User { get; set; } = new User();
}
