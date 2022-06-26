using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class CountryByIdSpec : Specification<Country>, ISingleResultSpecification
{
  public CountryByIdSpec(string id)
  {
    Query
    .AsNoTracking()
    .Where(x => x.Id == id);
  }
}
