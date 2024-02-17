using System.Linq.Expressions;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRapositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (var _context = new NorthwindContext())
            {
                
                var result = _context.Products.Select(p => new ProductDetailDto
                    {
                        ProductName = p.ProductName,
                        ProductId = p.ProductId,
                        CategoryName = _context.Categories.Where(category => category.CategoryId == p.CategoryId).SingleOrDefault().CategoryName,
                        UnitsInStock = p.UnitsInStock
                    }
                );
                return result.ToList();
            }
        }
    }
}
