using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Infrastructure.Data.Constants;
using ShadyNagy.ApiTemplate.Infrastructure.Data.Converters;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Config;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder
      .ToTable("Users", "Lockup")
      .HasKey(x => x.Id);

    builder
      .Property(p => p.Id)
      .HasColumnName("Id")
      .IsRequired();

    builder
      .Property(p => p.Username)
      .HasColumnName("Username")
      .HasMaxLength(DatabaseColumnsWidth.NAME)
      .IsRequired();

    builder
      .Property(p => p.Password)
      .HasColumnName("Password")
      .HasMaxLength(DatabaseColumnsWidth.NAME);

    builder
      .Property(p => p.IsActive)
      .HasColumnName("IsActive")
      .IsRequired();

    builder
      .Property(t => t.UserType)
      .HasColumnName("UserType")
      .HasMaxLength(DatabaseColumnsWidth.TYPE_ONE_CHAR)
      .HasConversion<UserTypeConverter>()
      .IsRequired();

  }
}
