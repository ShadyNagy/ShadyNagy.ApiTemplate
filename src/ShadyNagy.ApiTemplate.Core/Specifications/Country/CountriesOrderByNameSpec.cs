using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class CountriesOrderByNameSpec : Specification<Country>
{
  public CountriesOrderByNameSpec()
  {
    Query
      .OrderBy(x => x.Name);
  }
}
