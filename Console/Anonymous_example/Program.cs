using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Anonymous_example
{
    class Program
    {
        // Anonymous - Kiểu dữ liệu vô danh
        // Object - thuộc tính - chỉ đọc (Không gán, sửa được)
        // new {thuộc tính = giá trị, thuộc tính 2 = giá trị 2}

        // Dynamic - Kiểu dữ liệu động
        /*
         Biến kiểu động - ngầm định - khai báo với từ khóa dynamic, 
         thì kiểu thực sự của biến đó được xác định bằng đối tượng
         gán vào ở thời điểm chạy 
         (khác với kiểu ngầm định var kiểu xác định ngay thời điểm biên dịch)
        */

        class SinhVien
        {
            public string HoTen { set; get; }
            public int NamSinh { set; get; }
            public string NoiSinh { set; get; }

            public void Hello() => Console.WriteLine(HoTen);
        }
        static void Main(string[] args)
        {
            var sanpham = new
            {
                Ten = "Inphone 8",
                Gia = 1000,
                NamSX = 2018
            };

            Console.WriteLine(sanpham.Ten);
            Console.WriteLine(sanpham.Gia);
            //
            List<SinhVien> sinhViens = new List<SinhVien>(){
                new SinhVien(){HoTen = "Nam", NamSinh = 2000, NoiSinh = "Bình Dương"},
                new SinhVien(){HoTen = "Trung", NamSinh = 2001, NoiSinh = "Thanh Hóa"},
                new SinhVien(){HoTen = "Bình", NamSinh = 2002, NoiSinh = "Hà Nội"}
            };
            var ketqua = from sv in sinhViens
                         where sv.NamSinh <= 2001 && sv.HoTen.Contains("a")
                         select new
                         {
                             Ten = sv.HoTen,
                             NS = sv.NamSinh
                         };
            foreach (var sv in ketqua)
            {
                Console.WriteLine(sv.Ten + " - " + sv.NS);
            }
            // Dynamic
            dynamic sinhVien = new SinhVien();

            PrintInfo(sinhVien);

        }
        static void PrintInfo(dynamic obj)
        {
            obj.HoTen = "BinhNC";
            obj.Hello();
        }
    }
}
