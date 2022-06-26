using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class CitiesOrderByNameSpec : Specification<City>
{
  public CitiesOrderByNameSpec()
  {
    Query
      .OrderBy(x => x.Name);
  }
}
