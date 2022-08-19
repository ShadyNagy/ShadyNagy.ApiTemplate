using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications.Helpers;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public sealed class CountriesByFilterSpec : Specification<Country>
{
  public CountriesByFilterSpec(CountryFilter filter)
  {
    if (!filter.IsTrackingEnabled)
    {
      Query
        .AsNoTracking();
    }

    if (!string.IsNullOrEmpty(filter.Name))
    {
      Query
        .Where(c => c.CountryTranslations.Any(t => t.Name == filter.Name));
    }

    if (filter.LoadChildren)
    {
      Query
        .Include(c => c.CountryTranslations.Where(t => t.LanguageId == filter.LanguageId));
    }

    if (filter.IsPagingEnabled)
    {
      Query
        .Skip(PaginationHelper.CalculateSkip(filter))
        .Take(PaginationHelper.CalculateTake(filter));
    }

    Query
      .OrderBy(c => c.CountryTranslations.FirstOrDefault(t => t.LanguageId == filter.LanguageId)!.Name);
  }
}
