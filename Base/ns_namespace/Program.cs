using System;
using static System.Console;
using static System.Math;
using MyNameSpace;
using xyz = MyNameSpace.Abc;
using System.Text;

namespace ns_namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Green;

            // Class1.XinChao();
            // xyz.Class1.XinChao();
            // WriteLine("Xin Chào");
            // WriteLine(Sin(PI / 2));
            SanPham.Product product = new SanPham.Product();
            product.name = "IPad";
            product.price = 1000;
            product.description = "Đây là IPad";
            product.manufactory = new SanPham.Product.Manufactory();
            product.manufactory.name = "Apple";

            WriteLine(product.GetInfor());
            product.myMethod();

            //Reset màu
            Console.ResetColor();
        }
    }
}
