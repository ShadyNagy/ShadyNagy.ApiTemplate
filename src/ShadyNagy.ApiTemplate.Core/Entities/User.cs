using System;
using ShadyNagy.ApiTemplate.SharedKernel;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.Entities;
public class User : BaseEntity<Guid>, IAggregateRoot
{
  public string Username { get; set; } = string.Empty;
  public string? Password { get; set; } = string.Empty;
  public bool IsActive { get; set; }
  public UserType UserType { get; set; }
  public int UserInfoId { get; set; }
  public virtual UserInfo? UserInfo { get; set; }
}
