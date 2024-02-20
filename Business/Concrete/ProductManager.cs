using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IResult Add(Product product)
    {
        if (product.ProductName.Length < 2)
        {
            return new ErrorResult(Messages.ProductNameInvalide);
        }
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour == 22)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

    }

    public IDataResult<List<Product>> GetAllByCategory(int categoryId)
    {
        return new SuccessDataResult<List<Product>>
            (_productDal.GetAll(p => p.CategoryId == categoryId),
                Messages.ProductsListed);
    }



    public IDataResult<List<Product>> GetByProductName(string productName)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ProductName.Equals(productName)), Messages.ProductsListed);

    }


    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        if (min < 2500 || min > max)
        {
            return new ErrorDataResult<List<Product>>(Messages.LowerThanMinimumPrice);
        }
        if (max > 100000m || max < min)
        {
            return new ErrorDataResult<List<Product>>(Messages.HigherThanMaximumPrice);
        }
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min), Messages.ProductsListed);

    }

    public IDataResult<Product> GetProductById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(product => product.ProductId == productId), Messages.ProductsListed);

    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsListed);

    }
}