using System.Collections.Generic;

namespace ShadyNagy.ApiTemplate.SharedKernel;

// This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
public abstract class BaseEntity<T>
{
  public T? Id { get; set; }

  public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
}
