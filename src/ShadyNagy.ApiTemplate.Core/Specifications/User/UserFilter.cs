using System;

namespace ShadyNagy.ApiTemplate.Core.Specifications;

public class UserFilter : BaseFilter
{
  public Guid? Id { get; set; }
  public string Name { get; set; } = string.Empty;
}
