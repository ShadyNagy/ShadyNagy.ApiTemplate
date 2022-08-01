using ShadyNagy.ApiTemplate.Core.Interfaces;

namespace ShadyNagy.ApiTemplate.Core.AppSettings;
public class JwtSettings : IAppSettings
{
  public string ValidAudience { get; set; } = string.Empty;
  public string ValidIssuer { get; set; } = string.Empty;
  public string SecretKey { get; set; } = string.Empty;
}
