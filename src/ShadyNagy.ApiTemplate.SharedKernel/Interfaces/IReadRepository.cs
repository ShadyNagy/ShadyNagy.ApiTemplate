using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
  Task<int> GetMaxIdAsync(CancellationToken cancellationToken = default);
}
