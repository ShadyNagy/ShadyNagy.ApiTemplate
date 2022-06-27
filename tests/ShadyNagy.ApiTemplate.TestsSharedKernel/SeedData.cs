using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Infrastructure.Data;

namespace ShadyNagy.ApiTemplate.TestsSharedKernel;

public static class SeedData
{
  public static readonly Country TestCountry1 = new Country
  {
    Id = "EG",
    Name = "Egypt"
  };

  public static readonly Country TestCountry2 = new Country
  {
    Id = "KSA",
    Name = "Saudi Arabia"
  };

  public static readonly City TestCity1 = new City
  {
    CountryId = "EG",
    Name = "Cairo"
  };

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any TODO items.
      if (dbContext.Countries.Any())
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Cities)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.Countries)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    TestCountry1.AddCity(TestCity1);
    dbContext.Countries.Add(TestCountry1);

    dbContext.Countries.Add(TestCountry2);

    dbContext.SaveChanges();
  }
}
