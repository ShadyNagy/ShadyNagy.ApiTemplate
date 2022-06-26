using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class BranchByIdSpec : Specification<Branch>, ISingleResultSpecification
{
  public BranchByIdSpec(int id)
  {
    Query
    .AsNoTracking()
    .Where(x => x.Id == id);
  }
}
