using System;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal() => _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };

        public void Add(Product product)
            => _products.Add(product);

        public void Delete(Product product)
            => _ = _products.Remove(_products.SingleOrDefault(p => p.ProductId == product.ProductId));

        public void Update(Product product)
        {
            // Find the product to be updated
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            // Update the product
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public Product? Get(Expression<Func<Product, bool>> filter)
            => filter != null ? _products.SingleOrDefault(filter.Compile()) : _products.SingleOrDefault();

        public List<Product> GetAll(Expression<Func<Product, bool>> filter)
            => filter != null ? _products.Where(filter.Compile()).ToList() : _products;

    }
}
