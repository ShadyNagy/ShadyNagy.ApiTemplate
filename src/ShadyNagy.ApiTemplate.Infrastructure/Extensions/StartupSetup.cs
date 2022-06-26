using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShadyNagy.ApiTemplate.Infrastructure.Data;

namespace ShadyNagy.ApiTemplate.Infrastructure.Extensions;
public static class StartupSetup
{
  public static void AddDbContext(this IServiceCollection services, string connectionString, Action<DbContextOptionsBuilder> optionsAction) =>
    services.AddDbContext<AppDbContext>(optionsAction); // will be created in web project root
}
