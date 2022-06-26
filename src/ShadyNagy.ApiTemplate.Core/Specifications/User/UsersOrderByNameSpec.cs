using System.Linq;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class UsersOrderByNameSpec : Specification<User>
{
    public UsersOrderByNameSpec()
    {
        Query
          .OrderBy(x => x.Username);
    }
}
