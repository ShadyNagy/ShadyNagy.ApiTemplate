using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class BranchesOrderByNameSpec : Specification<Branch>
{
  public BranchesOrderByNameSpec()
  {
    Query
      .Include(a => a.City)
      .OrderBy(x => x.Name);
  }
}
