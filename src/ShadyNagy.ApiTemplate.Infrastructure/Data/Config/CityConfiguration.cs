using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Config;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
  public void Configure(EntityTypeBuilder<City> builder)
  {
    builder
      .ToTable("Cities", "Lockup")
      .HasKey(x => x.Id);

    builder
      .Property(p => p.Id)
      .HasColumnName("Id")
      .IsRequired();

    builder
      .Property(p => p.CountryId)
      .HasColumnName("CountryId");

    builder
      .HasOne(t => t.Country)
      .WithMany(p => p.Cities)
      .HasForeignKey(d => d.CountryId)
      .OnDelete(DeleteBehavior.ClientSetNull);

    builder
      .HasMany(c => c.CityTranslations)
      .WithOne(t => t.City)
      .HasForeignKey(t => t.CityId)
      .OnDelete(DeleteBehavior.ClientSetNull);
  }
}
