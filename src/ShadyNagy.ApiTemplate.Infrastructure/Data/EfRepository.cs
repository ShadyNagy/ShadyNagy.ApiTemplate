﻿using System.Linq;
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
    var entitiesTypes = _dbContext.Model.GetEntityTypes();
    var tableType = entitiesTypes.First(c => c.ClrType == typeof(T));
    foreach (var property in tableType.GetProperties())
    {
      if (property.Name.ToLower() != "id")
      {
        continue;
      }

      if (property.ClrType == typeof(int) || property.ClrType == typeof(decimal) ||
          property.ClrType == typeof(double) || property.ClrType == typeof(float))
      {
        return _dbContext.Set<T>()
          .MaxAsync(x =>
            EF.Property<int>(x, "Id"), cancellationToken);
      }
    }

    return Task.FromResult(0);
  }
}
