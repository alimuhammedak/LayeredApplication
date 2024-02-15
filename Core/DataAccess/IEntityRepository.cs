using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    // Generic constraint
    // class: reference type
    // IEntity: IEntity or a class that implements IEntity
    // new(): It must be a class that can be instantiated, that is, it must have a parameterless constructor.
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T Get(Expression<Func<T, bool>>? filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
