﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

var productManager = new ProductManager(new EfProductDal());

var result = productManager.GetAll();
if (result.IsSuccess)
{
    if (result.Data.Count < 1 || result is { Data: null })
        Console.WriteLine("Data yok");
    else
        foreach (var product in result.Data)
            Console.WriteLine(product.ProductName);
}
else
{
    Console.WriteLine(result.Message);
}


//foreach (var productDetail in productManager.GetProductDetails())
//{
//    Console.WriteLine($"{productDetail.ProductId,-10} \t{productDetail.ProductName,-32} \t{productDetail.CategoryName,-15} \t{productDetail.UnitsInStock}");
//}


//ProductTest();
//CategoryTest();
//void CategoryTest()
//{
//    OrderManager orderManager = new OrderManager(new EfOrderDal());
//    foreach (var order in orderManager.GetAll())
//    {
//        Console.WriteLine(order.shipCity);
//    }
//}

//void ProductTest()
//{
//    ProductManager productManager = new ProductManager(new EfProductDal());

//    using IEnumerator<Product> enumerable = productManager.GetAllByCategory(1).GetEnumerator();
//    using IEnumerator<Product> enumerator = productManager.GetByUnitPrice(10, 20).GetEnumerator();

//    while (enumerable.MoveNext())
//        Console.WriteLine($"{enumerable.Current.ProductName} ");
//    Console.WriteLine("---------------------------------");

//    while (enumerator.MoveNext())
//        Console.WriteLine($"{enumerator.Current.ProductName} ");
//}


//var products = productManager.GetAll();

//var productNames = products.Select(p => p.ProductName);

//Console.WriteLine(string.Join(" ", productNames));












