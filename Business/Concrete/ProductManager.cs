using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void Add(Product product)
    {
        _productDal.Add(product);
    }

    public void Delete(Product product)
    {
        _productDal.Delete(product);
    }

    public List<Product> GetAll()
    {
        return _productDal.GetAll();
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
        return _productDal.GetAllByCategory(categoryId);
    }

    public void Update(Product product)
    {
        _productDal.Update(product);
    }
}