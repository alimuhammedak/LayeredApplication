using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService:IEntityRepository<Product>
    {
        List<Product> GetAllByCategory(int categoryId); // Get all products by category
        List<Product> GetByUnitPrice(decimal min, decimal max); // Get all products by price range
        List<Product> GetByProductName(string productName); // Get all products by name
        List<ProductDetailDto> GetProductDetails();
    }
}
