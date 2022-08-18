using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Config;
public class CityTranslationConfiguration : IEntityTypeConfiguration<CityTranslation>
{
  public void Configure(EntityTypeBuilder<CityTranslation> builder)
  {
    builder
      .ToTable("CityTranslations", "Lockup")
      .HasKey(x => x.Id);
  }
}
