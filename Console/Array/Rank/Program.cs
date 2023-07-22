using System;

// Mảng nhiều chiều (rank)
namespace Rank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ví dụ với mảng 2 chiều 3x4 (3 hàng 4 cột)
            int[,] arr1 = new int[3, 4];
            // Để truy cập vào phần tử cụ thể của mảng, chỉ ra số chỉ số (bằng số chiều)
            arr1[0, 0] = 1; // Hàng 1, cột 1
            arr1[2, 3] = 1; // Hàng 3, cột 4

            // khai báo và khởi tạo mảng 2 chiều
            int[,] myvar = new int[3, 4] { { 1, 2, 3, 4 }, { 0, 3, 1, 3 }, { 4, 2, 3, 4 } };

            // Duyệt qua từng hàng
            for (int i = 0; i <= 2; i++)
            {
                // Duyệt qua từng cột
                for (int j = 0; j <= 3; j++)
                {
                    Console.Write(myvar[i, j] + " ");
                }
                Console.WriteLine();
            }
            // Mảng trong mảng
            int[][] myArray = new int[][] {
                                new int[] {1,2},
                                new int[] {2,5,6},
                                new int[] {2,3},
                                new int[] {2,3,4,5,5}
                               };

            foreach (var arr in myArray)
            {
                foreach (var e in arr)
                {
                    Console.Write(e + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
