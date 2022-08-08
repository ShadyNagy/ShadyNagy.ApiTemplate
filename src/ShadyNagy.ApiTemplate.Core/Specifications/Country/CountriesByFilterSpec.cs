using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications.Filters;
using ShadyNagy.ApiTemplate.Core.Specifications.Helpers;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class CountriesByFilterSpec : Specification<Country>
{
  public CountriesByFilterSpec(CountryFilter filter)
  {
    Query.OrderBy(x => x.Name);

    if (filter.LoadChildren)
      Query.Include(x => x.Cities);

    if (filter.IsPagingEnabled)
      Query.Skip(PaginationHelper.CalculateSkip(filter))
           .Take(PaginationHelper.CalculateTake(filter));

    if (!string.IsNullOrEmpty(filter.Name))
      Query.Where(x => x.Name == filter.Name);

    if (!string.IsNullOrEmpty(filter.Name))
      Query.Search(x => x.Name, "%" + filter.Name + "%");
  }
}
