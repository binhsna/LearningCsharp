using System;
using System.Linq;
using System.Text;
using MyLib;

namespace cs_ExtensionMethod
{
    // extension method
    // Lớp tĩnh static
    static class Abc
    {
        public static void Print(this string s, ConsoleColor color)
        {
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ForegroundColor = lastColor;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int[] mang = { 1, 2, 4, 6, 3 };
            int max = mang.Max();

            "Xin".Print(ConsoleColor.Blue);
            "Chào".Print(ConsoleColor.Red);
            "Các".Print(ConsoleColor.Cyan);
            "Bạn".Print(ConsoleColor.Yellow);

            double a = 2.5;
            Console.WriteLine(a.BinhPhuong());
            Console.WriteLine(a.CanBacHai());
            Console.WriteLine(a.Sin());
            Console.WriteLine(a.Cos());
        }
    }
}
