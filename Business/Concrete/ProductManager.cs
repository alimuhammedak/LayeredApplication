using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    private readonly ICategoryService _categoryService;

    public ProductManager(IProductDal productDal)
    {    
        _productDal = productDal;
    }

    //[SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        var result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), 
            CheckIfProductNameExist(product.ProductName));
        
        if (result != null)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        return result;
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour == 15) return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
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
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ProductName.Equals(productName)),
            Messages.ProductsListed);
    }


    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        if (min < 2500 || min > max) return new ErrorDataResult<List<Product>>(Messages.LowerThanMinimumPrice);
        if (max > 100000m || max < min) return new ErrorDataResult<List<Product>>(Messages.HigherThanMaximumPrice);
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min),
            Messages.ProductsListed);
    }

    public IDataResult<Product> GetProductById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(product => product.ProductId == productId),
            Messages.ProductBrought);
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsListed);
    }

    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        var result = _productDal.GetAll(p => p.CategoryId == categoryId).Any();
        if (result)
        {
            return new ErrorResult("Hata");
        }

        return new SuccessResult("Gecti");
    }

    private IResult CheckIfProductNameExist(string productName)
    {
        var result = _productDal.GetAll(p => p.ProductName == productName).Any();
        if (result)
        {
            return new ErrorResult("Hata");
        }

        return new SuccessResult("Gecti");
    }

    private IResult CheckIfCategoryLimitExceeded()
    {
        var result = _categoryService.GetAll();
        if (result.Data.Count > 15)
        {
            return new ErrorResult(Messages.CategoryLimitExceeded);
        }

        return new SuccessResult();
    }
}