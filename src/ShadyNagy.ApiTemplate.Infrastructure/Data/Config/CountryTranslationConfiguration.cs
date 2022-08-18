using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Config;
public class CountryTranslationConfiguration : IEntityTypeConfiguration<CountryTranslation>
{
  public void Configure(EntityTypeBuilder<CountryTranslation> builder)
  {
    builder
      .ToTable("CountryTranslations", "Lockup")
      .HasKey(x => x.Id);
  }
}
