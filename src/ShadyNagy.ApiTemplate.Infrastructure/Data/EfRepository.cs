using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  private readonly AppDbContext _dbContext;
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }

  public Task<int> GetMaxIdAsync(CancellationToken cancellationToken = default)
  {
    return _dbContext.Set<T>().MaxAsync(x => (int)x.GetType().GetProperty("Id")!.GetValue(x, null)!, cancellationToken);
  }
}
