using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EF
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbContext = new ProductDbContext();
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
            using var dbContext = new ProductDbContext();
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
            using var dbContext = new ProductDbContext();
            /*
            - Model (Product)
            - Add, AddAsyc
            - SaveChange
            */
            var products = new object[]{
                new Product(){ProductName="Sản phẩm 1", Provider="Công ty 1"},
                new Product(){ProductName="Sản phẩm 2", Provider="Công ty 2"},
                new Product(){ProductName="Sản phẩm 3", Provider="Công ty 3"},
                new Product(){ProductName="Sản phẩm 4", Provider="Công ty 4"},
                new Product(){ProductName="Sản phẩm 5", Provider="Công ty 5"},
           };
            dbContext.AddRange(products);
            int number_rows = dbContext.SaveChanges();
            Console.WriteLine($"Đã chèn {number_rows} dữ liệu");
        }

        static void ReadProducts()
        {
            using var dbContext = new ProductDbContext();
            // LinQ
            // var products = dbContext.products.ToList();
            // products.ForEach(p => p.PrintInfo());
            // var qr = from product in dbContext.products
            //          where product.ProductId >= 3
            //          orderby product.ProductId descending
            //          select product;
            // qr.ToList().ForEach(x => x.PrintInfo());

            Product product = (from p in dbContext.products
                               where p.Provider == "Công ty 3"
                               select p).FirstOrDefault();
            product?.PrintInfo();
        }
        static void RenameProduct(int id, string newName)
        {
            using var dbContext = new ProductDbContext();
            Product product = (from p in dbContext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            if (product != null)
            {
                // product -> DbContext
                // Theo dõi sự thay đổi của Model Product trong DbContext
                EntityEntry<Product> entry = dbContext.Entry(product);
                // entry.State = EntityState.Detached; // -> Thoát ra khỏi sự theo dõi -> Nên sẽ không tác động được vào bảng product trong database

                product.ProductName = newName;
                int number_rows = dbContext.SaveChanges();
                Console.WriteLine($"Cập nhật {number_rows} dữ liệu");
            }
        }

        static void DeleteProduct(int id)
        {
            using var dbContext = new ProductDbContext();
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
        static void Main(string[] args)
        {
            // Entity -> Database, Table
            // Database - SQL Server: data01 -> Kế thừa từ DbContext
            // -- product
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // CreateDatabase();
            //DropDatabase();

            // Insert, Select, Update, Delete -> CRUD
            // InsertProduct();
            ReadProducts();
            RenameProduct(4, "Samsung");
            // DeleteProduct(2);

            // Logging - Ghi lại lại code thao tác (Nhật ký thao tác)


        }
    }
}
