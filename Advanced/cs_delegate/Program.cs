using System;
using System.Text;

namespace cs_delegate
{
    // delegate (Type): Kiểu ủy quyền -> Tạo ra biến tham chiếu đến phương thức (Khá giống kiểu con trỏ)
    // Biến delegate có thể một lúc tham chiếu đến nhiều phương thức -> Tạo ra một chuỗi những tham chiếu -> (+=)
    class Program
    {
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        public delegate void ShowLog(string message);

        delegate int Kieu1();
        static int Tong(int a, int b) => a + b;
        static int Hieu(int a, int b) => a - b;
        static void Tong(int a, int b, ShowLog log)
        {
            int kq = a + b;
            log?.Invoke($"Tổng là {kq}");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            ShowLog log = null; // +=
            log = Info;
            // c1:
            if (log != null) log("Xin Chao");
            // c2:
            log?.Invoke("Xin chao cac ban");

            log = Warning;
            log?.Invoke("Warning");
            // Tạo nhiều tham chiếu
            log += Info;
            log += Warning;
            log?.Invoke("Xin chao cac ban 2");

            // Action, Func : delegate - generic
            Action action; // Tương đương với delegate void Kieu();
            Action<string, int> action1; // ~ delegate void Kieu(string s, int i);

            Action<string> action2;
            action2 = Warning;
            action2 += Info;
            action2?.Invoke("Thông báo từ Action");
            // Sử dụng Func thì phải có kiểu trả về
            // Kieu1 f1;
            // Kiểu trả về được liệt kê ở cuối cùng, kiểu của các tham số được liệt kê ở phía trước
            Func<int> f1; // ~ delegate int Kieu();
            Func<string, double, string> f2; // ~ delegate string Kieu(string s, double a));

            Func<int, int, int> tinhtoan; // ~ delegate int Kieu(int a, int b);
            int a = 5, b = 10;
            tinhtoan = Tong;

            Console.WriteLine($"KQ = {tinhtoan(a, b)}");

            Tong(4, 5, Info);
        }
    }
}
