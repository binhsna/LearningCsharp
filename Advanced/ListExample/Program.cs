using System;
using System.Collections.Generic;
using System.Text;

namespace ListExample
{
    class Program
    {
        class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int ID { get; set; }
            public string Origin { get; set; } // Nguồn gốc, xuất xứ
        }
        // List
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            List<int> list = new List<int>() { 7, 8, 9 };
            list.Add(1);
            list.Add(2);
            // Thêm 1 mảng các phần tử
            list.AddRange(new int[] { 3, 4, 5 });
            // Chèn vào 1 vị trí xác định
            list.Insert(0, 100);
            // Console.WriteLine(list.Count);
            // Console.WriteLine(list[2]);
            // Xóa phần tử tại vị trí xác định
            // list.RemoveAt(2);
            // Xóa phần tử xác định (Xóa đi phần tử đầu tiên bắt gặp)
            // list.Remove(9);

            foreach (var n in list)
            {
                Console.WriteLine(n);
            }
            // Tìm kiếm phần tử trong danh sách
            var x = list.Find(x => x % 2 == 0); // Trả về phần tử đầu tiên thỏa mãn điều kiện
            Console.WriteLine(x);
            // Trả về 1 danh sách các phần tử thỏa mãn điều kiện
            var rs = list.FindAll(x => x % 2 == 0);
            foreach (var n in rs)
            {
                Console.WriteLine(n);
            }
            List<Product> products = new List<Product>()
            {
                new Product{Name = "Iphone X", Price = 1000, Origin = "China", ID = 1},
                new Product{Name = "Samsung", Price = 900, Origin = "China", ID = 2},
                new Product{Name = "Sony", Price = 1100, Origin = "Japan", ID = 3},
                new Product{Name = "Nokia", Price = 800, Origin = "China", ID = 4},
            };
            // Japan
            var p = products.Find(p =>
            {
                return (p.Origin == "Japan" && p.Name.StartsWith("S"));
            });
            if (p != null)
            {
                Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
            }
            Console.WriteLine("--------------------------------------");
            // Sắp xếp tăng dần theo Price
            products.Sort(
                (p1, p2) =>
                {
                    if (p1.Price == p2.Price) return 0;
                    if (p1.Price < p2.Price) return -1;
                    return 1;
                }
            );
            // In ra danh sách các phần tử trong products
            foreach (var pp in products)
            {
                Console.WriteLine($"{pp.Name} - {pp.Price} - {pp.Origin}");
            }
            // SortedList
            SortedList<string, Product> pp1 = new SortedList<string, Product>();
            pp1["sanpham1"] = new Product { Name = "Iphone", Price = 1000, Origin = "China" };
            pp1["sanpham2"] = new Product { Name = "Samsung", Price = 900, Origin = "China" };
            pp1.Add("sanpham3", new Product { Name = "Nokia", Price = 900, Origin = "China" });

            var ppp = pp1["sanpham2"];
            Console.WriteLine(ppp.Name);

            // Duyệt qua keys
            var keys = pp1.Keys;
            var values = pp1.Values;

            foreach (var k in keys)
            {
                var ps = pp1[k];
                Console.WriteLine(ps.Name);
            }
            //
            foreach (KeyValuePair<string, Product> item in pp1)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Name}");
            }
            pp1.Remove("sanpham1");
            pp1.RemoveAt(0);
            // Xóa tất cả các phần tử
            pp1.Clear();
        }
    }
}
