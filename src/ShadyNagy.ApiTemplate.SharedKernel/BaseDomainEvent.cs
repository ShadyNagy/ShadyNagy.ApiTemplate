using System;
using MediatR;

namespace ShadyNagy.ApiTemplate.SharedKernel;

public abstract class BaseDomainEvent : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
