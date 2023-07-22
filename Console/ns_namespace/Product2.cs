using System;

namespace SanPham
{
    public partial class Product
    {
        public Manufactory manufactory { set; get; }
        public class Manufactory
        {
            public string name { set; get; }
            public string address { set; get; }
        }

        public string description { get; set; }
        public partial void myMethod()
        {
            Console.WriteLine("Partial với các phương thức");
        }
    }
}