using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace cs_event
{
    public delegate void SuKienNhapSo(int x);
    /*
        publisher -> class - phát sự kiện
        subscriber -> class - nhận sự kiện
    */
    // publisher
    class DuLieuNhap : EventArgs
    {
        public int data { get; set; }
        public DuLieuNhap(int x) => data = x;
    }
    class UserInput
    {
        // public event SuKienNhapSo suKienNhapSo;

        // ~ delegate void Kieu(object? sender, EventArgs args);
        public event EventHandler suKienNhapSo;
        public void Input()
        {
            do
            {
                Console.Write("Nhập vào 1 số nguyên: ");
                string s = Console.ReadLine();
                int i = Int32.Parse(s);
                // Phát đi sự kiện
                // suKienNhapSo?.Invoke(i);
                suKienNhapSo?.Invoke(this, new DuLieuNhap(i));
            } while (true);
        }
    }

    class TinhCan
    {
        // Đăng ký nhận sự kiện
        public void Sub(UserInput input)
        {
            input.suKienNhapSo += Can;
        }
        // public void Can(int i)
        // {
        //     Console.WriteLine($"Căn bậc hai của {i} là {Math.Sqrt(i)}");
        // }
        public void Can(object sender, EventArgs e)
        {
            DuLieuNhap duLieuNhap = (DuLieuNhap)e;
            int i = duLieuNhap.data;
            Console.WriteLine($"Căn bậc hai của {i} là {Math.Sqrt(i)}");
        }
    }
    class BinhPhuong
    {
        // Đăng ký nhận sự kiện
        public void Sub(UserInput input)
        {
            input.suKienNhapSo += TinhBinhPhuong;
        }
        // public void TinhBinhPhuong(int i)
        // {
        //     Console.WriteLine($"Bình phương của {i} là {i * i}");
        // }
        public void TinhBinhPhuong(object sender, EventArgs e)
        {
            DuLieuNhap duLieuNhap = (DuLieuNhap)e;
            int i = duLieuNhap.data;
            Console.WriteLine($"Bình phương của {i} là {i * i}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("");
                Console.WriteLine("Thoát ứng dụng");
            };

            // publisher
            UserInput userInput = new UserInput();
            userInput.suKienNhapSo += (sender, e) =>
            {
                DuLieuNhap duLieuNhap = (DuLieuNhap)e;
                Console.WriteLine("Bạn vừa nhập số: " + duLieuNhap.data);
            };

            // subscriber
            TinhCan tinhCan = new TinhCan();
            tinhCan.Sub(userInput);

            BinhPhuong binhPhuong = new BinhPhuong();
            binhPhuong.Sub(userInput);

            userInput.Input();

            //
        }
    }
}
