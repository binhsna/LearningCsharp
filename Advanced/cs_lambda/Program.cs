using System;
using System.Linq;
using System.Text;

namespace cs_lambda
{
    /*
    Lambda - Anonymous function (Phương thức không tên, vô danh) -> Được gán cho 1 biến delegate
    // 2 Cách khai báo
    1) (tham số) => biểu thức;
    2) (tham số) => {
        Các biểu thức;
        return (biểu thức trả về);
    }
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Action<string> thongbao;
            thongbao = (string s) => Console.WriteLine(s); // ~ delegate void Kieu(string s);
            thongbao = s => Console.WriteLine(s);
            thongbao?.Invoke("Xin chào");
            Action thongbao2;
            thongbao2 = () => Console.WriteLine("Xin chào các bạn");
            thongbao2?.Invoke();

            Action<string, string> thongbao3;
            thongbao3 = (msg1, msg2) =>
            {
                Console.WriteLine($"{msg1}");
                Console.WriteLine($"{msg2}");
            };
            thongbao3?.Invoke("Xin Chào", "Nguyễn Công Bình");

            Func<int, int, int> tinhtoan;
            tinhtoan = (a, b) =>
            {
                int kq = a + b;
                return kq;
            };
            Console.WriteLine(tinhtoan?.Invoke(5, 6));

            int[] mang = { 2, 3, 4, 5, 6, 7, 99, 22 };
            var kq = mang.Select((int x) =>
                        {
                            return Math.Sqrt(x);
                        });

            foreach (var result in kq)
            {
                Console.WriteLine(result);
            }
            // 
            mang.ToList().ForEach(
                (int x) =>
                {
                    if (x % 2 != 0) Console.WriteLine(x);
                });
            //
            var kq1 = mang.Where(x => x % 4 == 0);
            foreach (var n in kq1)
            {
                Console.WriteLine(n);
            }
        }
    }
}
