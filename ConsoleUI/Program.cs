using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new EfProductDal());

using IEnumerator<Product> enumerable = productManager.GetAllByCategory(1).GetEnumerator();
using IEnumerator<Product> enumerator = productManager.GetByUnitPrice(10, 20).GetEnumerator();

while (enumerable.MoveNext())
    Console.WriteLine($"{enumerable.Current.ProductName} ");
Console.WriteLine("---------------------------------");

while (enumerator.MoveNext())
    Console.WriteLine($"{enumerator.Current.ProductName} ");


//var products = productManager.GetAll();

//var productNames = products.Select(p => p.ProductName);

//Console.WriteLine(string.Join(" ", productNames));
