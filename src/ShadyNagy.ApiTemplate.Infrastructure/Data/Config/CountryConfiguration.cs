using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Infrastructure.Data.Constants;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Config;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
  public void Configure(EntityTypeBuilder<Country> builder)
  {
    builder
      .ToTable("Countries", "Lockup")
      .HasKey(x => x.Id);

    builder
      .Property(p => p.Id)
      .HasColumnName("Id")
      .IsRequired();

    builder
      .Property(p => p.Name)
      .HasColumnName("Name")
      .HasMaxLength(DatabaseColumnsWidth.NAME)
      .IsRequired();
  }
}
