using System;
using System.Text;

namespace cs_017
{
    // Phương thức tĩnh
    class CountNumber
    {
        public static int number = 0;
        public static void Info()
        {
            Console.WriteLine("Số lần truy cập: " + number);
        }
        public void Count()
        {
            // number++;
            CountNumber.number++;
        }
    }
    // Dữ liệu chỉ đọc
    class Student
    {
        public readonly string name; // Chỉ đọc
        public Student(string _name)
        {
            this.name = _name;
        }
    }
    // Quá tải toán tử
    class Vector
    {
        double x;
        double y;
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine($"Khởi tạo Vector({x}, {y})");
        }
        // Phương thức (Hàm) hủy
        ~Vector()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Gọi hàm hủy Vector({x}, {y})");
            Console.ResetColor();
        }
        public void Info()
        {
            Console.WriteLine($"x = {x}, y = {y}");
        }
        // vector <- vector + vector
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector operator +(Vector v1, double v2)
        {
            return new Vector(v1.x + v2, v1.y + v2);
        }
        // Indexer
        public double this[int index]
        {
            set
            {
                switch (index)
                {
                    case 0: // x
                        x = value;
                        break;
                    case 1: //y
                        y = value;
                        break;
                    default:
                        throw new Exception("Chỉ số bị sai");
                }
            }
            get
            {
                switch (index)
                {
                    case 0: // x
                        return x;
                    case 1: //y
                        return y;
                    default:
                        throw new Exception("Chỉ số bị sai");
                }
            }
        }
        public double this[string s]
        {
            set
            {
                switch (s)
                {
                    case "toadox": // x
                        x = value;
                        break;
                    case "toadoy": //y
                        y = value;
                        break;
                    default:
                        throw new Exception("Chỉ số bị sai");
                }
            }
            get
            {
                switch (s)
                {
                    case "toadox": // x
                        return x;
                    case "toadoy": //y
                        return y;
                    default:
                        throw new Exception("Chỉ số bị sai");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // CountNumber.Info();
            // Console.WriteLine(CountNumber.number);

            CountNumber c1 = new CountNumber();
            CountNumber c2 = new CountNumber();

            c1.Count();
            c2.Count();
            CountNumber.Info();

            Student s = new Student("BinhNC");
            Console.WriteLine(s.name);

            // 
            Vector v1 = new Vector(2, 3);
            Vector v2 = new Vector(1, 1);

            // (x1, y1) + (x2, y2) = (x1 + x2, y1 + y2)
            var v3 = v1 + v2;
            v1.Info();
            v2.Info();
            v3.Info();
            var v4 = v1 + 10;
            v4.Info();
            //
            Vector v = new Vector(2, 3);
            // v[0] ~ x; v[1] ~ y
            // v["toadox"] ~ x; v["toadoy"] ~ y

            v[0] = 5;
            v[1] = 6;
            v.Info();
            //Console.WriteLine(v[3]);

            v["toadox"] = 10;
            v["toadoy"] = 20;
            v.Info();

            // Ví dụ về hàm hủy
            Vector vh;
            for (int i = 0; i < 100066; i++)
            {
                vh = new Vector(i, i);
                vh = null;
            }
            // Ép hệ thống thu hồi bộ nhớ (Thực tế không cần ép, nó sẽ tự động chạy khi cần)
            GC.Collect(); // Dùng trong net framework, net core không còn hỗ trợ
        }
    }
}
