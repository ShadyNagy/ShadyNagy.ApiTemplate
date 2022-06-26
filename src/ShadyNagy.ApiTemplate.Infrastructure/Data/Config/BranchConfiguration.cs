using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Infrastructure.Data.Constants;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Config;
public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
  public void Configure(EntityTypeBuilder<Branch> builder)
  {
    builder
      .ToTable("Branches", "Lockup")
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

    builder
      .Property(p => p.Address)
      .HasColumnName("Address")
      .HasMaxLength(DatabaseColumnsWidth.ADDRESS)
      .IsRequired();

    builder
      .Property(p => p.CityId)
      .HasColumnName("CityId")
      .IsRequired();

    builder
      .Property(p => p.Email)
      .HasMaxLength(DatabaseColumnsWidth.EMAIL)
      .HasColumnName("Email");

    builder
      .Property(p => p.Phone)
      .HasColumnName("Phone")
      .HasMaxLength(DatabaseColumnsWidth.PHONE);

    builder
      .HasOne(t => t.City)
      .WithMany(p => p.Branches)
      .HasForeignKey(d => d.CityId)
      .OnDelete(DeleteBehavior.ClientSetNull);

  }
}
