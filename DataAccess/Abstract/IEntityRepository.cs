using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
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
