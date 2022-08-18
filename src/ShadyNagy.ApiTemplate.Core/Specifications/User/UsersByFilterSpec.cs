using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications.Helpers;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public sealed class UsersByFilterSpec : Specification<User>
{
  public UsersByFilterSpec(UserFilter filter)
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

    if (filter.IsPagingEnabled)
    {
      Query
        .Skip(PaginationHelper.CalculateSkip(filter))
        .Take(PaginationHelper.CalculateTake(filter));
    }

    Query
      .OrderBy(u => u.Username);
  }
}
