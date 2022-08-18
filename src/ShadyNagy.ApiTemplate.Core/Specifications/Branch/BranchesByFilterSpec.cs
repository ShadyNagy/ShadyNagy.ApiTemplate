using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications.Helpers;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public sealed class BranchesByFilterSpec : Specification<Branch>
{
  public BranchesByFilterSpec(BranchFilter filter)
  {
    if (!filter.IsTrackingEnabled)
    {
      Query
        .AsNoTracking();
    }

    if (!string.IsNullOrEmpty(filter.Name))
    {
      Query
        .Search(b => b.Name, $"% {filter.Name} %");
    }

    if (!string.IsNullOrEmpty(filter.Address))
    {
      Query
        .Search(b => b.Address, $"% {filter.Address} %");
    }

    if (filter.CityId != null)
    {
      Query
        .Where(b => b.CityId == filter.CityId);
    }

    if (filter.LoadChildren)
    {
      Query
        .Include(b => b.City);
    }

    if (filter.IsPagingEnabled)
    {
      Query
        .Skip(PaginationHelper.CalculateSkip(filter))
        .Take(PaginationHelper.CalculateTake(filter));
    }

    Query
      .OrderBy(b => b.Name);
  }
}
