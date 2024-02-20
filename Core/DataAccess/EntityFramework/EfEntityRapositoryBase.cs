using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRapositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    void IEntityRepository<TEntity>.Add(TEntity entity)
    {
        var context = new TContext();
        var addedEntry = context.Entry(entity);
        addedEntry.State = EntityState.Added;
        context.SaveChanges();
    }

    void IEntityRepository<TEntity>.Delete(TEntity entity)
    {
        using var context = new TContext();
        var deletedEntry = context.Entry(entity);
        deletedEntry.State = EntityState.Deleted;
        context.SaveChanges();
    }

    TEntity IEntityRepository<TEntity>.Get(Expression<Func<TEntity, bool>>? filter)
    {
        using var context = new TContext();
        return context.Set<TEntity>().FirstOrDefault(filter.Compile());
    }

    List<TEntity> IEntityRepository<TEntity>.GetAll(Expression<Func<TEntity, bool>>? filter)
    {
        using var context = new TContext();
        return filter == null
            ? context.Set<TEntity>().ToList()
            : context.Set<TEntity>().Where(filter.Compile()).ToList();
    }

    void IEntityRepository<TEntity>.Update(TEntity entity)
    {
        using var context = new TContext();
        var deletedEntry = context.Entry(entity);
        deletedEntry.State = EntityState.Deleted;
        context.SaveChanges();
    }
}