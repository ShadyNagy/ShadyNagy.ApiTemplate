using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public sealed class BranchByIdSpec : Specification<Branch>, ISingleResultSpecification
{
  public BranchByIdSpec(BranchFilter filter)
  {
    if (!filter.IsTrackingEnabled)
    {
      Query
        .AsNoTracking();
    }

    if (filter.LoadChildren)
    {
    }

    Query
      .Where(b => b.Id == filter.Id);
  }
}
