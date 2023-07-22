using System;
using System.Linq;

namespace ArrayExample
{
    class ArrayExample1
    {
        static void Main(string[] args)
        {
            // Khai báo mảng kiểu phần tử là int (chưa khởi tạo)
            int[] bienMang;
            // Khởi tạo mảng -> gán vào biến mảng
            bienMang = new int[5];
            // Có thể khởi tạo ngay khi khai báo
            string[] studentNames = new string[10];
            // Khởi tạo mảng với số phần tử chỉ định và có giá trị khởi tạo mặc định
            string[] productNames = new string[3] { "Iphone", "Samsung", "Nokia" };
            // Vì khi khởi tạo với các giá trị mặc định thì không nhất thiết phải khai báo số lượng phần tử
            double[] productPrices = new double[] { 100, 200.5, 10.1 };
            double[] productPoints = { 100, 200.5, 10.1 };
            double a = productPoints.Min();
            testForEach();
            testFindAll();
            // Các cách duyệt qua các phần tử mảng
            // Duyệt qua bằng lệnh for
            int[] myArray = { 1, 3, 5, 19, 10, 20, 40, 40 };
            int maxIndex = myArray.Length - 1;
            for (int idx = 0; idx <= maxIndex; idx++)
            {
                Console.Write(myArray[idx] + " ");
            }
            Console.WriteLine();
            // Duyệt qua bằng lệnh foreach
            int[] myArray2 = { 1, 2, 3, 44, 21, 100, 9 };
            foreach (var element in myArray2)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
        static void testForEach()
        {
            int[] numbers = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            Array.ForEach<int>(numbers, (int n) => {
                Console.Write(n + " ");
            });
            Console.WriteLine();
        }
        static void testFindAll()
        {
            int[] numbers = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Định nghĩa Predicate là một delegate tham số kiểu int
            // trả về true nếu số chia hết cho 2
            Predicate<int> predicate = (int number) => {
                return number % 2 == 0;
            };
            // Tìm các số chẵn
            int[] cacsochan = Array.FindAll(numbers, predicate);

            // In kết quả
            Action<int> printnumber = (int number) => Console.WriteLine(number);
            Array.ForEach(cacsochan, printnumber);
        }
    }
}
