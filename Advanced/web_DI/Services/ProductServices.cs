
using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string ID { get; set; } // Mã sản phẩm
    public string Name { get; set; }
    public double Price { get; set; }
}

public class ProductService
{
    List<Product> products = new List<Product>();

    public ProductService()
    {
        Console.WriteLine("Khoi tao ProductService");
        products.AddRange(new Product[]{
            new Product(){ID = "product01", Name = "Dien thoai Iphone 8", Price = 1000},
            new Product(){ID = "product02", Name = "Dien thoai Sony", Price = 900},
            new Product(){ID = "product03", Name = "Laptop Samsung", Price = 2000},
            new Product(){ID = "product04", Name = "May tinh bang", Price = 500},
        });
    }

    public Product FindProduct(string productID)
    {
        var qr = from p in products where p.ID == productID select p;
        return qr.FirstOrDefault();
    }
}