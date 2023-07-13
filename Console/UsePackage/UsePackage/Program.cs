
using System;
using System.Text;
using BNC.Utils;

namespace UsePackage
{
    class Program
    {
        static void Main(string[] args)
        {
            // fix xuất ra màn hình bằng tiếng việt
            Console.OutputEncoding = Encoding.Unicode;
            // fix nhập vào bằng tiếng việt
            Console.InputEncoding = Encoding.Unicode;

            const string lbName = "Nhập tên: ";
            const string lbShowName = "Xin chào: ";
            Console.Write(lbName);
            var name = Console.ReadLine();
            Console.WriteLine($"{lbShowName}{name}");
            double a = 438932843;
            var result = ConvertMoneyToText.NumberToText(a);
            Console.WriteLine($"Số tiền trong tài khoản của bạn: {result}");
        }
    }
}
