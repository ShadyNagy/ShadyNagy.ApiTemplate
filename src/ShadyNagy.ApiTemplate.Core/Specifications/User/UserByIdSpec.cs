using System;
using Ardalis.Specification;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Specifications;
public class UserByIdSpec : Specification<User>, ISingleResultSpecification
{
  public UserByIdSpec(Guid id)
  {
    Query
    .AsNoTracking()
    .Include(x => x.UserInfo)
    .Where(x => x.Id == id);
  }
}
