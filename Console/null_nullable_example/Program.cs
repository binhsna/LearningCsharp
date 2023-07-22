using System;

namespace null_nullable_example
{
    class Abc
    {
        public void XinChao() => Console.WriteLine("Xin chào C#");
    }
    class Program
    {
        // null, nullable
        // null
        static void Main(string[] args)
        {
            Abc abc = new Abc();
            //if (abc != null)
            //   abc.XinChao();
            abc?.XinChao();

            // nullable
            //Nullable<int> bienkieuint;
            int? age;
            age = 100;

            if (age.HasValue)
            {
                int _age = age.Value;
                Console.WriteLine(_age);
            }
        }
    }
}
