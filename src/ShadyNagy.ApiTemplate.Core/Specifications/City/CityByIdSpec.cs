using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public sealed class CityByIdSpec : Specification<City>, ISingleResultSpecification
{
  public CityByIdSpec(CityFilter filter)
  {
    if (!filter.IsTrackingEnabled)
    {
      Query
        .AsNoTracking();
    }

    if (filter.LoadChildren)
    {
      Query
        .Include(c => c.CityTranslations.Where(t => t.LanguageId == filter.LanguageId));
    }

    Query
      .Where(c => c.Id == filter.Id);
  }
}
