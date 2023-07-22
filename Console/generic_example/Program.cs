using System;

namespace generic_example
{
    class Program
    {
        class Product<A>
        {
            A ID;
            public void SetID(A id_)
            {
                this.ID = id_;
            }
            public void PrintInf()
            {
                Console.WriteLine($"ID = {this.ID}");
            }
        }
        static void Swap<T>(ref T x, ref T y)
        {
            T t;
            t = x;
            x = y;
            y = t;
        }
        static void Main(string[] args)
        {
            int a = 5;
            int b = 45;

            Console.WriteLine($"a = {a}, b = {b}");
            Swap<int>(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");

            Product<int> product = new Product<int>();
            product.SetID(123);
            product.PrintInf();
        }
    }
}
