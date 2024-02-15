using Entities.Concrete;
using System.Linq.Expressions;
using Core.DataAccess;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        Customer Get(Expression<Func<Customer, bool>> filter);
    }
}
