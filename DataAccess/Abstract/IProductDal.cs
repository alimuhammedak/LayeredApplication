using Entities.Concrete;
using Core.DataAccess;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
