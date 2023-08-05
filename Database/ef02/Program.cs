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
        }

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
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            DropDatabase();
            CreateDatabase();

            // InsertData();



        }
    }
}
