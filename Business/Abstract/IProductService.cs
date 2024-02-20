using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetAllByCategory(int categoryId); // Get all products by category
    IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max); // Get all products by price range
    IDataResult<List<Product>> GetByProductName(string productName); // Get all products by name
    IDataResult<List<ProductDetailDto>> GetProductDetails();
    IDataResult<Product> GetProductById(int productId);
    IResult Add(Product product);
}