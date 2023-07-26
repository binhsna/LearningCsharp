using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace LinqExample
{
    // LINQ (Language Integrated Query): Ngôn ngữ truy vấn tích hợp
    // SQL
    // Nguồn dữ liệu: IEnumerable, IEnumerable<T> (Array, List, Stack, Queue,...)
    // XML, SQL
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; } // Tên
        public double Price { get; set; } // Giá
        public string[] Colors { get; set; } // Các màu
        public int Brand { get; set; } // ID nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id;
            Name = name;
            Price = price;
            Colors = colors;
            Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẩm gồm ID, Name, Price
        override public string ToString() => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
    }
    public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // Product p = new Product(1, "Abc", 1000, new string[] { "Xanh", "Do" }, 2);
            // Console.WriteLine(p.ToString());

            var brands = new List<Brand>()
            {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>(){
                new Product(1, "Bán trà", 400, new string[] { "Xám", "Xanh"}, 2),
                new Product(2, "Tranh treo", 400, new string[] { "Vàng", "Xanh"}, 1),
                new Product(3, "Đèn trùm", 500, new string[] { "Trắng"}, 3),
                new Product(4, "Bàn học", 200, new string[] { "Trắng", "Xanh"}, 1),
                new Product(5, "Túi da", 300, new string[] { "Đỏ", "Đen", "Vàng"}, 2),
                new Product(6, "Giường ngủ", 500, new string[] { "Trắng"}, 2),
                new Product(7, "Tủ áo", 600, new string[] { "Trắng"}, 3),
            };
            // Lấy ra sản phẩm giá 400
            var query = from p in products
                        where p.Price == 400
                        select p;

            foreach (var product in query)
            {
                Console.WriteLine(product);
            }
            // Select
            var kq = products.Select(p =>
             {
                 return new
                 {
                     Ten = p.Name,
                     Gia = p.Price
                 };
             });
            foreach (var item in kq)
            {
                Console.WriteLine(item);
            }
            // Where
            var kq1 = products.Where(p =>
            {
                return p.Name.Contains("tr");
            });

            foreach (var item in kq1)
            {
                Console.WriteLine(item);
            }
            // SelectMany
            var kq2 = products.SelectMany(p =>
           {
               return p.Colors;
           });

            foreach (var item in kq2)
            {
                Console.WriteLine(item);
            }
            // Min, Max, Sum, Average
            int[] numbers = { 1, 2, 3, 4, 5, 6, 12, 13 };
            Console.WriteLine(numbers.Where(n => n % 2 != 0).Sum());
            Console.WriteLine(products.Average(p => p.Price));
            // Join
            var kq3 = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
            {
                return new
                {
                    Ten = p.Name,
                    ThuongHieu = b.Name
                };
            });
            foreach (var item in kq3)
            {
                Console.WriteLine(item);
            }
            // GroupJoin
            var kq4 = brands.GroupJoin(products, b => b.ID, p => p.Brand
            , (brand, pros) =>
            {
                return new
                {
                    ThuongHieu = brand.Name,
                    CacSanPham = pros
                };
            });
            foreach (var gr in kq4)
            {
                Console.WriteLine(gr.ThuongHieu);
                foreach (var p in gr.CacSanPham)
                {
                    Console.WriteLine(p);
                }
            }
            // Take: Lấy ra số phần tử đầu tiên
            products.Take(4).ToList().ForEach(p => Console.WriteLine(p));
            // Skip: Bỏ qua số phần tử đầu tiên
            products.Skip(2).ToList().ForEach(p => Console.WriteLine(p));
            // OrderBy (Tăng dần) / OrderByDescending (Giảm dần)
            products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));
            // Reverse: Đảo ngược thứ tự phần tử
            numbers.Reverse().ToList().ForEach(p => Console.WriteLine(p));
            // GroupBy: Nhóm theo trường xác định
            var kq5 = products.GroupBy(p => p.Price);
            foreach (var group in kq5)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group)
                {
                    Console.WriteLine(p);
                }
            }
            // Distinct: Loại bỏ những phần tử có cùng giá trị
            products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(mau => Console.WriteLine(mau));
            // Single, SingleOrDefault(null: mặc định) -> Chỉ trả về 1 phần tử -> Nếu không thì lỗi
            var pt = products.Single(p => p.Price == 600);
            pt = products.SingleOrDefault(p => p.Price == 1600);
            Console.WriteLine(pt);
            // Any: Trả về true/false (True: Tồn tại 1 phần tử thỏa mãn điều kiện)
            var pAny = products.Any(p => p.Price == 400);
            Console.WriteLine(pAny);
            // All: Trả về true/false (True: Khi tất cả các phần tử thỏa mãn điều kiện)
            var pAll = products.All(p => p.Price == 400);
            Console.WriteLine(pAll);
            // Count: Đếm số lượng các phần tử (Thêm điều kiện nếu có)
            var pCount = products.Count(p => p.Price == 400);
            Console.WriteLine(pCount);
            // In ra tên sản phẩm, tên thương hiệu, có giá (300 - 400)
            // Giá giảm dần
            products.Where(p => p.Price >= 300 && p.Price <= 400)
            .OrderByDescending(p => p.Price)
            .Join(brands, p => p.Brand, b => b.ID, (sp, th) =>
            {
                return new
                {
                    TenSP = sp.Name,
                    TenTH = th.Name,
                    Gia = sp.Price
                };
            }).ToList().ForEach(info =>
            {
                Console.WriteLine($"{info.TenSP,15} {info.TenTH,15}, {info.Gia,5}");
            });

            /*
             --> Cú pháp của LINQ cơ bản:
                1) Xác định nguồn: from tenphantu in IEnumerable
                   ... join, where, orderby, let tenbien = ???
                2) Lấy dữ liệu: select, group by ...
            */
            Console.WriteLine("--------------------------------");
            // var qr = from a in products select $"{a.Name}: {a.Price}";
            // var qr1 = from a in products
            //           select new
            //           {
            //               Ten = a.Name,
            //               Gia = a.Price
            //           };
            // qr.ToList().ForEach(name => Console.WriteLine(name));

            // Giá <= 500, màu xanh
            // var qr = from product in products
            //          from color in product.Colors
            //          where product.Price <= 500 && color == "Xanh"
            //          orderby product.Price descending
            //          select new
            //          {
            //              Ten = product.Name,
            //              Gia = product.Price,
            //              CacMau = product.Colors
            //          };
            // qr.ToList().ForEach(rs =>
            // {
            //     Console.WriteLine($"{rs.Ten} - {rs.Gia} {string.Join(",", rs.CacMau)}");
            // });
            // Nhóm sản phẩm theo giá
            // var qr = from p in products
            //          group p by p.Price into gr
            //          orderby gr.Key
            //          select gr;
            // qr.ToList().ForEach(group =>
            // {
            //     Console.WriteLine(group.Key);
            //     group.ToList().ForEach(p => Console.WriteLine(p));
            // });

            // Đối tượng: Giá, Các sản phẩm, số lượng
            // var qr = from p in products
            //          group p by p.Price into gr
            //          orderby gr.Key
            //          let sl = "Số lượng là " + gr.Count()
            //          select new
            //          {
            //              Gia = gr.Key,
            //              CacSanPham = gr.ToList(),
            //              SoLuong = sl
            //          };
            // qr.ToList().ForEach(i =>
            // {
            //     Console.WriteLine(i.Gia);
            //     Console.WriteLine(i.SoLuong);
            //     i.CacSanPham.ForEach(p => Console.WriteLine(p));
            // });

            // Inner join
            // var qr = from product in products
            //          join brand in brands on product.Brand equals brand.ID
            //          select new
            //          {
            //              ten = product.Name,
            //              gia = product.Price,
            //              thuonghieu = brand.Name
            //          };

            // Left join
            var qr = from product in products
                     join brand in brands on product.Brand equals brand.ID into t
                     from b in t.DefaultIfEmpty()
                     select new
                     {
                         ten = product.Name,
                         gia = product.Price,
                         thuonghieu = (b != null) ? b.Name : "No Brand"
                     };

            qr.ToList().ForEach(o =>
            {
                Console.WriteLine($"{o.ten,10} {o.thuonghieu,15} {o.gia,5}");
            });

        }
    }
}