using Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Product? Get(Expression<Func<Product, bool>> filter);
    }
}
