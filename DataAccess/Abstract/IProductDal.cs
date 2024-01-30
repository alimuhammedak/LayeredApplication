using Entities.Concrete;
using System;
using System.Linq;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll(); // List all products
        List<Product> GetAllByCategory(int categoryId); // List all products by category 
        void Add(Product product); // Add a product
        void Update(Product product); // Update a product
        void Delete(Product product); // Delete a product
    }
}
