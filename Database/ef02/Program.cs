using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
// dotnet add package Microsoft.EntityFrameworkCore.Proxies -> Không khuyến khích sử dụng vì khá nặng
namespace ef02
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbContext = new ShopContext();
            string dbName = dbContext.Database.GetDbConnection().Database;

            var kq = dbContext.Database.EnsureCreated();
            if (kq)
            {
                Console.WriteLine($"Tạo db {dbName} thành công");
            }
            else
            {
                Console.WriteLine($"Không tạo được {dbName}");
            }
            // Console.WriteLine(dbName);
        }
        static void DropDatabase()
        {
            using var dbContext = new ShopContext();
            string dbName = dbContext.Database.GetDbConnection().Database;

            var kq = dbContext.Database.EnsureDeleted();
            if (kq)
            {
                Console.WriteLine($"Xóa db {dbName} thành công");
            }
            else
            {
                Console.WriteLine($"Không xóa được {dbName}");
            }
            // Console.WriteLine(dbName);
        }
        static void InsertProduct()
        {
            using var dbContext = new ShopContext();
            /*
            - Model (Product)
            - Add, AddAsyc
            - SaveChange
            */
            //     var products = new object[]{
            //         new Product(){Name="Sản phẩm 1", Provider="Công ty 1"},
            //         new Product(){Name="Sản phẩm 2", Provider="Công ty 2"},
            //         new Product(){Name="Sản phẩm 3", Provider="Công ty 3"},
            //         new Product(){Name="Sản phẩm 4", Provider="Công ty 4"},
            //         new Product(){Name="Sản phẩm 5", Provider="Công ty 5"},
            //    };
            //     dbContext.AddRange(products);
            //     int number_rows = dbContext.SaveChanges();
            //     Console.WriteLine($"Đã chèn {number_rows} dữ liệu");
        }

        static void ReadProducts()
        {
            using var dbContext = new ShopContext();
            // LinQ
            // var products = dbContext.products.ToList();
            // products.ForEach(p => p.PrintInfo());
            // var qr = from product in dbContext.products
            //          where product.ProductId >= 3
            //          orderby product.ProductId descending
            //          select product;
            // qr.ToList().ForEach(x => x.PrintInfo());

            // Product product = (from p in dbContext.products
            //                    where p.Provider == "Công ty 3"
            //                    select p).FirstOrDefault();
            // product?.PrintInfo();
        }
        static void RenameProduct(int id, string newName)
        {
            using var dbContext = new ShopContext();
            Product product = (from p in dbContext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            if (product != null)
            {
                // product -> DbContext
                // Theo dõi sự thay đổi của Model Product trong DbContext
                EntityEntry<Product> entry = dbContext.Entry(product);
                // entry.State = EntityState.Detached; // -> Thoát ra khỏi sự theo dõi -> Nên sẽ không tác động được vào bảng product trong database

                product.Name = newName;
                int number_rows = dbContext.SaveChanges();
                Console.WriteLine($"Cập nhật {number_rows} dữ liệu");
            }
        }

        static void DeleteProduct(int id)
        {
            using var dbContext = new ShopContext();
            Product product = (from p in dbContext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            if (product != null)
            {
                dbContext.Remove(product);
                int number_rows = dbContext.SaveChanges();
                Console.WriteLine($"Đã xóa {number_rows} dữ liệu");
            }
        }
        //
        static void InsertData()
        {
            using var dbContext = new ShopContext();

            Category c1 = new Category() { Name = "Điện thoại", Description = "Các loại điện thoại" };
            Category c2 = new Category() { Name = "Đồ uống", Description = "Các loại đồ uống" };
            dbContext.categories.Add(c1);
            dbContext.categories.Add(c2);

            // var c1 = (from c in dbContext.categories where c.CategoryId == 1 select c).FirstOrDefault();
            // var c2 = (from c in dbContext.categories where c.CategoryId == 2 select c).FirstOrDefault();

            dbContext.Add(new Product() { Name = "Iphone8", Price = 1000, CategoryId = 1 });
            dbContext.Add(new Product() { Name = "Samsung", Price = 900, Category = c1 });
            dbContext.Add(new Product() { Name = "Rượu vang đỏ", Price = 500, Category = c2 });
            dbContext.Add(new Product() { Name = "Nokia 1280", Price = 600, Category = c1 });
            dbContext.Add(new Product() { Name = "Cafe đen", Price = 100, Category = c2 });

            int number_rows = dbContext.SaveChanges();
            Console.WriteLine($"Đã chèn {number_rows} dữ liệu");
        }
        static void Main(string[] args)
        {
            // Entity -> Database, Table
            // Database - SQL Server: data01 -> Kế thừa từ DbContext
            // -- product
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // DropDatabase();
            // CreateDatabase();

            // Insert, Select, Update, Delete -> CRUD
            // InsertProduct();
            // ReadProducts();
            // RenameProduct(4, "Samsung");
            // DeleteProduct(2);

            // Logging - Ghi lại lại code thao tác (Nhật ký thao tác)

            // InsertData();

            using var dbContext = new ShopContext();
            var product = (from p in dbContext.products where p.ProductId == 3 select p).FirstOrDefault();

            // Có thể bỏ đi vì đã cài package Microsoft.EntityFrameworkCore.Proxies
            // var e = dbContext.Entry(product);
            // e.Reference(p => p.Category).Load();

            product?.PrintInfo();
            if (product.Category != null)
            {
                Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");
            }
            else
            {
                Console.WriteLine("Category == null");
            }

            var category = (from c in dbContext.categories where c.CategoryId == 2 select c).FirstOrDefault();
            Console.WriteLine($"{category.CategoryId} - {category.Name}");

            // var ec = dbContext.Entry(category);
            // ec.Collection(c => c.Products).Load();

            if (category.Products != null)
            {
                Console.WriteLine($"Số sản phẩm: {category.Products.Count}");
                category.Products.ForEach(p => p.PrintInfo());
            }
            else
            {
                Console.WriteLine($"Products == null");
            }
            //
            var p1 = dbContext.products.Find(2);
            p1?.PrintInfo();
            //
            var products = from p in dbContext.products
                           where p.Name.ToLower().Contains("i")
                           orderby p.Price descending
                           select p;
            products.Take(2).ToList().ForEach(p => p.PrintInfo());
            //
            var kq = from p in dbContext.products
                     join c in dbContext.categories on p.CategoryId equals c.CategoryId
                     select new
                     {
                         ten = p.Name,
                         danhmuc = c.Name,
                         gia = p.Price
                     };
            kq.ToList().ForEach(p => Console.WriteLine(p));

        }
    }
}
