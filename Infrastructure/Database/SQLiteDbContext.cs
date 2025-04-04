using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database;

internal class SQLiteDbContext : DbContext, IDbContext
{
    public SQLiteDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<ValueEntity> ValueEntities { get; set; }

    public DbSet<RequestLog> RequestLogs { get; set; }

    public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
    {
        return base.Add(entity);
    }

    public Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class => base.AddRangeAsync(entities);

    public Task<int> RemoveAllAsync<TEntity>(IQueryable<TEntity> source) where TEntity : class
        => source.ExecuteDeleteAsync();
    
    public Task SaveChangesAsync() => base.SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ValueEntity>().HasKey(p => p.Index);
        modelBuilder.Entity<RequestLog>().HasKey(r => r.Id);
    }

    
}
