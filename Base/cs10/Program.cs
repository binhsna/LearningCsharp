using System;
using System.Text;

namespace cs10
{
    // virtual method => là phương thức có thể định nghĩa lại bởi lớp kế thừa
    class Product
    {
        protected double Price { set; get; }
        public virtual void ProductInfo()
        {
            Console.WriteLine($"Giá sản phẩm: {Price}");
        }
        public void Test() => ProductInfo();
    }

    abstract class ProductAbstract
    {
        protected double Price { set; get; }
        public abstract void ProductInfo();
        public void Test() => ProductInfo();
    }
    class Iphone : Product
    {
        public Iphone() => Price = 500;
        // override - Nạp chồng phương thức -> Định nghĩa lại phương thức ở lớp cơ sở
        public override void ProductInfo()
        {
            Console.WriteLine("Điện thoại Iphone");
            base.ProductInfo();
        }
    }
    class Iphone2 : ProductAbstract
    {
        public override void ProductInfo()
        {
            Console.WriteLine("Điện thoại Iphone 2");
        }
    }
    // interface
    interface IHinhHoc
    {
        public double TinhChuVi();
        public double TinhDienTich();
    }
    class HinhChuNhat : IHinhHoc
    {
        public double a { set; get; }
        public double b { set; get; }
        public HinhChuNhat(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public double TinhChuVi()
        {
            return 2 * (a + b);
        }

        public double TinhDienTich()
        {
            return a * b;
        }
    }
    class HinhTron : IHinhHoc
    {
        public double r { set; get; }
        public HinhTron(double r) => this.r = r;

        public double TinhChuVi()
        {
            return 2 * r * Math.PI;
        }

        public double TinhDienTich()
        {
            return r * r * Math.PI;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Iphone iphone = new Iphone();
            iphone.Test();

            Iphone2 iphone2 = new Iphone2();
            iphone2.Test();

            HinhChuNhat h = new HinhChuNhat(4, 5);
            Console.WriteLine($"Diện tích: {h.TinhDienTich()}, Chu vi: {h.TinhChuVi()}");

            HinhTron ht = new HinhTron(3);
            Console.WriteLine($"Diện tích: {ht.TinhDienTich()}, Chu vi: {ht.TinhChuVi()}");

            Console.ResetColor();
        }
    }
}
