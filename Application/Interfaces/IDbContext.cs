using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IDbContext
{
    public DbSet<ValueEntity> ValueEntities { get;  }

    public DbSet<RequestLog> RequestLogs { get; }

    Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : class;

    Task<int> RemoveAllAsync<TEntity>(IQueryable<TEntity> source) where TEntity : class;

    Task SaveChangesAsync();
}
