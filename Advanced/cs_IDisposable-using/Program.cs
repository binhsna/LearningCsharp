using System;
using System.IO;
using System.Text;

namespace cs_IDisposable_using
{
    public class WriteData : IDisposable
    {

        // trường lưu trạng thái Dispose
        private bool m_Disposed = false;

        private StreamWriter stream;

        public WriteData(string filename)
        {
            stream = new StreamWriter(filename, true);
        }

        // Phương thức triển khai từ giao diện
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Nếu disposing = true -> Được thi hành do gọi trực tiếp (do Dispose gọi)
        // tài nguyên managed, unmanaged được giải phóng
        // nếu disposing = false -> Được thi hành bởi phương thức hủy, chỉ cần giải phóng
        // các toàn nguyên unmanaged.
        protected virtual void Dispose(bool disposing)
        {
            if (!m_Disposed)
            {
                if (disposing)
                {
                    // các đối tượng có Dispose gọi ở đây
                    stream.Dispose();
                }

                // giải phóng các tài nguyên không quản lý được cửa lớp (unmanaged)

                m_Disposed = true;
            }
        }
        // Finalize
        ~WriteData()
        {
            Dispose(false);
        }

    }
    class A : IDisposable
    {
        bool resource = true;
        public void Dispose()
        {
            Console.WriteLine("Phương thức này được gọi tự động khi hết using");
            resource = false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            using (var a = new A())
            {
                Console.WriteLine("Do something ...");
            }
            // Triển khai IDisposable cùng với hàm Hủy
            using (WriteData writeData = new WriteData("text.txt"))
            {
                // do something
            }
            // Nếu không dùng using thì chủ động gọi Dispose
            WriteData writeData1 = new WriteData("text.txt");
            //do something
            writeData1.Dispose();
        }
    }
}
