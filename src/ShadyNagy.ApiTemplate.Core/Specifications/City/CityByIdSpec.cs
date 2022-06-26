using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class CityByIdSpec : Specification<City>, ISingleResultSpecification
{
  public CityByIdSpec(int id)
  {
    Query
    .AsNoTracking()
    .Where(x => x.Id == id);
  }
}
