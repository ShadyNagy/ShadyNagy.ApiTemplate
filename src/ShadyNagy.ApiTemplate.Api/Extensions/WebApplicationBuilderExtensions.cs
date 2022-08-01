using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ShadyNagy.ApiTemplate.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
  public static WebApplicationBuilder AddAppSettings(this WebApplicationBuilder webApplicationBuilder)
  {
    webApplicationBuilder.Services.AddSingleton(webApplicationBuilder.Configuration.GetJwtSettings());

    return webApplicationBuilder;
  }
}
