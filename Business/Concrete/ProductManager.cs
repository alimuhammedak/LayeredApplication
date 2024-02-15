using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public List<Product> GetAll() => _productDal.GetAll();

    public List<Product> GetAllByCategory(int categoryId) =>
        _productDal.GetAll(p => p.CategoryId == categoryId);

    public List<Product> GetByProductName(string productName) =>
        _productDal.GetAll(p => p.ProductName.Equals(productName));

    public List<Product> GetByUnitPrice(decimal min, decimal max) =>
        _productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min);
    
}