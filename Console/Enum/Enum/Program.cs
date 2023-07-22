using System;
using System.Text;

namespace Enum
{
    class Program
    {
        // Kiểu enum
        /*
            0 - Kém
            1 - Trung bình
            2 - Khá
            3 - Giỏi
         */
        enum HOCLUC
        {
            Kem,
            TrungBinh = 98,
            Kha,
            Gioi
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            HOCLUC hocluc;
            hocluc = HOCLUC.Gioi;
           // hocluc = (HOCLUC)(67);

            int so = (int)hocluc;
            Console.WriteLine(so);

            switch (hocluc)
            {
                case HOCLUC.Kem:
                    Console.WriteLine("Học lực kém");
                    break;
                case HOCLUC.TrungBinh:
                    Console.WriteLine("Học lực trung bình");
                    break;
                case HOCLUC.Kha:
                    Console.WriteLine("Học lực khá");
                    break;
                case HOCLUC.Gioi:
                    Console.WriteLine("Học lực giỏi");
                    break;
            }
        }
    }
}
