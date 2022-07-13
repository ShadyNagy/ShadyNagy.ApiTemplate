using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Converters;
public class UserTypeConverter : ValueConverter<UserType, string>
{
  public UserTypeConverter()
      : base(
          coreValue => ToString(coreValue),
          efValue => FromString(efValue))
  {
  }

  private static string ToString(UserType type)
  {
    return type switch
    {
      UserType.Customer => "C",
      UserType.Employee => "E",
      _ => throw new System.NotImplementedException(),
    };
  }

  private static UserType FromString(string type)
  {
    return type.ToUpper() switch
    {
      "C" => UserType.Customer,
      "E" => UserType.Employee,
      _ => throw new System.NotImplementedException(),
    };
  }
}
