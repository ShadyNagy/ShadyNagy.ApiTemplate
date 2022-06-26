using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class UsersOrderByNameSpec : Specification<User>
{
  public UsersOrderByNameSpec()
  {
    Query
      .Include(x => x.UserInfo)
      .OrderBy(x => x.Username);
  }
}
