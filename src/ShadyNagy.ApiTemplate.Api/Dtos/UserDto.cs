using System;
using System.ComponentModel.DataAnnotations;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Api.Dtos;
public class UserDto
{
  public Guid Id { get; set; }
  [Required]
  public string Username { get; set; } = string.Empty;
  public string? Password { get; set; } = string.Empty;
  public bool IsActive { get; set; }
  public UserType UserType { get; set; }
  public int UserInfoId { get; set; }
  public UserInfoDto? UserInfo { get; set; }
}
