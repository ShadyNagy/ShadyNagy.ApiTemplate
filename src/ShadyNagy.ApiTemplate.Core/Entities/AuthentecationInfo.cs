namespace ShadyNagy.ApiTemplate.Core.Entities;
public class AuthenticationInfo
{
  public int UserId { get; set; }
  public string UserName { get; set; }  = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string FullName { get; set; } = string.Empty;
  public string Code { get; set; } = string.Empty;
}
