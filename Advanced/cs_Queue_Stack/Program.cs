using System;
using System.Collections.Generic;
using System.Text;

namespace cs_Queue_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            // Queue: Hàng đợi -> Vào trước ra trước
            Queue<string> cachoso = new Queue<string>();
            // Thêm vào cuối danh sách
            cachoso.Enqueue("Hồ sơ 1");
            cachoso.Enqueue("Hồ sơ 2");
            cachoso.Enqueue("Hồ sơ 3");
            foreach (var hs in cachoso)
            {
                Console.WriteLine(hs);
            }
            // Lấy và xóa/bớt phần tử ở đầu danh sách
            var hoso = cachoso.Dequeue();
            Console.WriteLine($"Xử lý hồ sơ: {hoso} - {cachoso.Count}");

            hoso = cachoso.Dequeue();
            Console.WriteLine($"Xử lý hồ sơ: {hoso} - {cachoso.Count}");

            hoso = cachoso.Dequeue();
            Console.WriteLine($"Xử lý hồ sơ: {hoso} - {cachoso.Count}");

            // Stack: Ngăn xếp -> Vào sau ra trước
            Stack<string> hanghoa = new Stack<string>();
            // Thêm vào đỉnh stack
            hanghoa.Push("Mặt hàng 1");
            hanghoa.Push("Mặt hàng 2");
            hanghoa.Push("Mặt hàng 3");
            //  Lấy và xóa/bớt phần tử ở đỉnh stack
            var mathang = hanghoa.Pop();
            Console.WriteLine($"Bốc dỡ: {mathang} - {hanghoa.Count}");

            mathang = hanghoa.Pop();
            Console.WriteLine($"Bốc dỡ: {mathang} - {hanghoa.Count}");

            mathang = hanghoa.Pop();
            Console.WriteLine($"Bốc dỡ: {mathang} - {hanghoa.Count}");

            // LinkedList: Danh sách liên kiết
            LinkedList<string> cacbaihoc = new LinkedList<string>();
            var bh1 = cacbaihoc.AddFirst("Bài học 1");
            var bh3 = cacbaihoc.AddLast("Bài học 3");
            LinkedListNode<string> bh2 = cacbaihoc.AddAfter(bh1, "Bài học 2");
            cacbaihoc.AddLast("Bài học 4");
            cacbaihoc.AddLast("Bài học 5");
            foreach (var data in cacbaihoc)
            {
                Console.WriteLine(data);
            }
            Console.WriteLine("----------------------------");
            var node = bh2;
            Console.WriteLine(node.Value);
            node = node.Previous;
            if (node != null)
                Console.WriteLine(node.Value);
            node = node.Next;
            Console.WriteLine(node.Value);
            Console.WriteLine("----------------------------");

            // Dictionary: Khá giống với SortedList, Dictionary nhằm mục đích 
            // -> Tăng tốc độ truy vấn, truy cập đến các phần tử bằng Key của nó dựa trên các tập dữ liệu lớn
            // Khởi tạo với 2 phần tử
            Dictionary<string, int> sodem = new Dictionary<string, int>()
            {
                ["one"] = 1,
                ["two"] = 2,
            };
            // Thêm hoặc cập nhật
            sodem["three"] = 3;
            sodem.Add("four", 4);

            foreach (KeyValuePair<string, int> item in sodem)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
            Console.WriteLine("----------------------------");

            // HashSet: Tập hợp danh sách các phần tử không cho phép trùng giá trị
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7 };
            HashSet<int> set2 = new HashSet<int>() { 8, 9, 1, 2, 7, 10 };

            set1.Add(11);
            set1.Remove(7);
            // Phép hợp set2 vào set1
            set1.UnionWith(set2);
            foreach (var item in set1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------");

            // Phép giao set1 = set1 giao set2
            set1.IntersectWith(set2);
            foreach (var item in set1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
