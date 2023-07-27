using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace type_attr
{
    class Program
    {
        // Type -> Là lớp Chứa những thông tin về một kiểu dữ liệu nào đó: class, struct, ... int, bool ...
        // Attribute: Thuộc tính bổ sung -> Sử dụng trong các thư viện là chính
        // Kỹ thuật Reflection: Thông tin kiểu dữ liệu ở thời điểm thực thi
        // AttributeName

        // ObsoleteAttribute

        /**
            Mô tả (Mota)
                - Thông tin chi tiết (Thongtinchitiet)
        */
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // Mota được sử dụng ở đâu (lớp, property, method,...)
        class MotaAttribute : Attribute
        {
            public string Thongtinchitiet { get; set; }
            public MotaAttribute(string _Thongtinchitiet)
            {
                Thongtinchitiet = _Thongtinchitiet;
            }

        }
        [Mota("Lớp chứa thông tin về User trên hệ thống")]
        class User
        {
            [Mota("Tên người dùng")]
            [Required(ErrorMessage = "Name phải được thiết lập")]
            [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên phải dài từ 3 đến 100 ký tự")]
            public string Name { get; set; }
            [Mota("Dữ liệu tuổi")]
            [Range(18, 80, ErrorMessage = "Tuổi phải từ 18 - 80")]
            public int Age { get; set; }
            [Mota("Số điện thoại cá nhân")]
            [Phone(ErrorMessage = "Số điện thoại phải đúng định dạng")]
            public string PhoneNumber { get; set; }
            [Mota("Địa chỉ Email")]
            [EmailAddress(ErrorMessage = "Địa chỉ email sai cấu trúc")]
            public string Email { get; set; }
            // Đánh dấu là lỗi thời (Obsolete)
            [Obsolete("Phương thức này không nên sử dụng nữa, cần thay bởi ShowInfo")]
            public void PrintInfo() => Console.WriteLine(Name);
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int[] a = { 1, 2, 3 };

            Type t1 = typeof(int);
            var t2 = typeof(string);
            var t3 = typeof(Array);
            var t = a.GetType();
            Console.WriteLine(t);
            Console.WriteLine("------------ Các thuộc tính");
            t.GetProperties().ToList().ForEach(
                (PropertyInfo o) =>
                {
                    Console.WriteLine(o.Name);
                });
            Console.WriteLine("------------ Các phương thức");
            t.GetMethods().ToList().ForEach(
                (MethodInfo o) =>
                {
                    Console.WriteLine(o.Name);
                });
            //
            User user = new User()
            {
                Name = "BinhNC",
                Age = 21,
                PhoneNumber = "0971912776",
                Email = "binhNC@gmail.com"
            };
            var properties = user.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                foreach (var attr in property.GetCustomAttributes(false))
                {
                    MotaAttribute mota = attr as MotaAttribute;
                    if (mota != null)
                    {
                        Console.WriteLine(mota.Thongtinchitiet);
                        var value = property.GetValue(user);
                        var name = property.Name;
                        Console.WriteLine($"({name}) - {mota.Thongtinchitiet} : {value}");
                    }
                }
            }
            user.PrintInfo();

            User user1 = new User()
            {
                Name = "ab",
                Age = 21,
                PhoneNumber = "0971912776",
                Email = "binhNC@gmail.com"
            };
            ValidationContext context = new ValidationContext(user1);
            var result = new List<ValidationResult>();
            bool kq = Validator.TryValidateObject(user1, context, result, true);
            if (kq == false)
            {
                result.ToList().ForEach(err =>
                {
                    Console.WriteLine(err.MemberNames.First());
                    Console.WriteLine(err.ErrorMessage);
                });
            }

        }
    }
}
