using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public sealed class CountryByIdSpec : Specification<Country>, ISingleResultSpecification
{
  public CountryByIdSpec(CountryFilter filter)
  {
    if (!filter.IsTrackingEnabled)
    {
      Query
        .AsNoTracking();
    }

    if (filter.LoadChildren)
    {
      Query
        .Include(c => c.CountryTranslations)
          .ThenInclude(c => c.LanguageId == filter.LanguageId);
    }

    Query
      .Where(c => c.Id == filter.Id);
  }
}
