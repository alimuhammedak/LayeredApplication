using Entities.Concrete;
using System;
using System.Linq;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(); // Get all products
        List<Product> GetAllByCategory(int categoryId); // Get all products by category
        void Add(Product product); // Add a product
        void Update(Product product); // Update a product
        void Delete(Product product); // Delete a product
    }
}
