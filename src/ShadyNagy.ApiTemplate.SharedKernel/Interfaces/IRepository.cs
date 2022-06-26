using Ardalis.Specification;

namespace ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
