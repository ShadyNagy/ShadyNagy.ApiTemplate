using System;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public sealed class UserByIdSpec : Specification<User>, ISingleResultSpecification
{
  public UserByIdSpec(UserFilter filter)
  {
    if (!filter.IsTrackingEnabled)
    {
      Query
        .AsNoTracking();
    }

    if (filter.LoadChildren)
    {
      Query
        .Include(u => u.UserInfo);
    }

    Query
      .Where(u => u.Id == filter.Id);
  }
}
