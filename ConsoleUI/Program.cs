using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new InMemoryProductDal());

using IEnumerator<Product> enumerable = productManager.GetAll().GetEnumerator();

while (enumerable.MoveNext())
    Console.WriteLine($"{enumerable.Current.ProductName} ");


var products = productManager.GetAll();

var productNames = products.Select(p => p.ProductName);

Console.WriteLine(string.Join(" ", productNames));
