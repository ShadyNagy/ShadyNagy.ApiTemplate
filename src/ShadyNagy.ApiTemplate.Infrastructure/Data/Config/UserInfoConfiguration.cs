using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Infrastructure.Data.Constants;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Config;
public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
  public void Configure(EntityTypeBuilder<UserInfo> builder)
  {
    builder
      .ToTable("UserInfos", "Lockup")
      .HasKey(x => x.Id);

    builder
      .Property(p => p.Id)
      .HasColumnName("Id")
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
      .HasOne(t => t.User)
      .WithOne(p => p.UserInfo)
      .HasForeignKey<User>(x => x.UserInfoId)
      .OnDelete(DeleteBehavior.ClientSetNull);

    builder
      .HasOne(t => t.City)
      .WithMany(p => p.UserInfos)
      .HasForeignKey(d => d.CityId)
      .OnDelete(DeleteBehavior.ClientSetNull);
  }
}
