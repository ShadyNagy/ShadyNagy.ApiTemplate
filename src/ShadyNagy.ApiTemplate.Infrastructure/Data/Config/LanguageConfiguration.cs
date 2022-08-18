using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Config;
public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
  public void Configure(EntityTypeBuilder<Language> builder)
  {
    builder
      .ToTable("Languages", "Lockup")
      .HasKey(x => x.Id);

    builder
      .Property(p => p.Id)
      .HasColumnName("Id")
      .IsRequired();

    builder
      .Property(p => p.Name)
      .HasColumnName("Name")
      .IsRequired();

    builder
      .HasMany(l => l.CityTranslations)
      .WithOne(t => t.Language)
      .HasForeignKey(t => t.LanguageId)
      .OnDelete(DeleteBehavior.ClientSetNull);
  }
}
