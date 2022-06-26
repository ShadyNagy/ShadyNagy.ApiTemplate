using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class BranchesByCityIdSpec : Specification<Branch>, ISingleResultSpecification
{
  public BranchesByCityIdSpec(int cityId)
  {
    Query
    .AsNoTracking()
    .Where(x => x.CityId == cityId);
  }
}
