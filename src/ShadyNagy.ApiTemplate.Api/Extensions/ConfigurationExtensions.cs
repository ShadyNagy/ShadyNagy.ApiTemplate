using Microsoft.Extensions.Configuration;
using ShadyNagy.ApiTemplate.Core.AppSettings;

namespace ShadyNagy.ApiTemplate.Api.Extensions;

public static class ConfigurationExtensions
{
  public static JwtSettings GetJwtSettings(this IConfiguration configuration)
  {
    return GetSection<JwtSettings>(configuration, "JwtSettings");
  }

  private static T GetSection<T>(IConfiguration configuration, string key) where T : new()
  {
    var section = configuration?.GetSection(key);
    var data = new T();
    section.Bind(data);

    return data;
  }
}
