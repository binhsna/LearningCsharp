using System;
using System.IO;
using System.Text;
using MyExceptions;

namespace cs_Exception
{
    class Program
    {
        // Phát sinh ra các Exception
        static void Register(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NameEmptyException();
            }
            if (age < 18 || age > 100)
            {
                // throw new Exception("Tuoi phai >=18 va <= 100");
                throw new AgeException(age);
            }
            // ...
            Console.WriteLine($"Xin chào {name} ({age})");
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int a = 5; int b = 3;
            // (float) / 0 = ∞

            // Exception
            // Bắt Exception
            try
            {
                // Các lệnh
                var c = a / b; // Phát sinh đối tượng lớp Exception, kế thừa Exception
                Console.WriteLine(c);
                int[] i = { 1, 2 };
                var x = i[5];
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Không được chia cho 0");
            }
            catch (IndexOutOfRangeException e1)
            {
                Console.WriteLine("Chỉ số mảng không phù hợp");
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
                Console.WriteLine(e2.StackTrace);
                Console.WriteLine(e2.GetType().Name); // In ra kiểu Exception
            }
            //
            string path = "1.txt";
            try
            {
                string s = File.ReadAllText(path);
                Console.WriteLine(s);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("File không tồn tại");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Đường dẫn file phải khác null");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            // Phát sinh Exception
            try
            {
                Register("BinhNC", 10);
            }
            catch (NameEmptyException nee)
            {
                Console.WriteLine(nee.Message);
            }
            catch (AgeException ae)
            {
                Console.WriteLine(ae.Message);
                ae.Detail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Kết thúc");
        }
    }
}
