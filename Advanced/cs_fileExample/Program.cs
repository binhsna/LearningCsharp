using System;
using System.IO;
using System.Text;
// Làm việc với File cơ bản lưu và đọc file text
namespace cs_fileExample
{
    class Product
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public void Save(Stream stream)
        {
            // int -> 4 byte
            var bytes_id = BitConverter.GetBytes(ID);
            stream.Write(bytes_id, 0, 4);

            // double -> 8 byte
            var bytes_price = BitConverter.GetBytes(Price);
            stream.Write(bytes_price, 0, 8);

            // Chuỗi Name
            var bytes_name = Encoding.UTF8.GetBytes(Name);
            var bytes_length = BitConverter.GetBytes(bytes_name.Length);
            stream.Write(bytes_length, 0, 4);
            stream.Write(bytes_name, 0, bytes_name.Length);
        }
        public void Restore(Stream stream)
        {
            // int -> 4 byte
            var bytes_id = new byte[4];
            stream.Read(bytes_id, 0, 4);
            ID = BitConverter.ToInt32(bytes_id, 0);
            // double -> 8 byte
            var bytes_price = new byte[8];
            stream.Read(bytes_price, 0, 8);
            Price = BitConverter.ToDouble(bytes_price, 0);
            // Chuỗi Name
            var bytes_length = new byte[4];
            stream.Read(bytes_length, 0, 4);
            int leng = BitConverter.ToInt32(bytes_length, 0);

            var bytes_name = new byte[leng];
            stream.Read(bytes_name, 0, leng);
            Name = Encoding.UTF8.GetString(bytes_name, 0, leng);
        }
    }
    class Program
    {
        // DriveInfo -> Thông tin của ổ đĩa
        // Directory -> Tương tác với các thư mục 
        // Path
        // File
        static void ListFileDirectory(string path)
        {
            String[] directories = System.IO.Directory.GetDirectories(path);
            String[] files = System.IO.Directory.GetFiles(path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
                ListFileDirectory(directory); // Đệ quy
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            // DriveInfo
            var drives = DriveInfo.GetDrives(); // Lấy tất cả các ổ đĩa
            // DriveInfo driveInfo = new DriveInfo("C");
            foreach (var drive in drives)
            {
                Console.WriteLine($"Drive: {drive.Name}");
                Console.WriteLine($"Drive Type: {drive.DriveType}");
                Console.WriteLine($"Label: {drive.VolumeLabel}");
                Console.WriteLine($"Format: {drive.DriveFormat}");
                Console.WriteLine($"Size: {drive.TotalSize}");
                Console.WriteLine($"Free: {drive.TotalFreeSpace}");
                Console.WriteLine("------------------------");
            }
            // Directory
            // Tạo thư mục
            //Directory.CreateDirectory("Abc");
            // Xóa thư mục
            //Directory.Delete("Abc");

            // Kiểm tra thư mục có tồn tại?
            string path = "obj";
            if (Directory.Exists(path))
            {
                Console.WriteLine($"Thư mục {path} - tồn tại");
            }
            else
            {
                Console.WriteLine($"Thư mục {path} - không tồn tại");
            }
            // Lấy tất cả các file trong path
            var files = Directory.GetFiles(path);
            // Lấy ra các thư mục con trong path
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }
            Console.WriteLine("------------------------");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            // Path
            ListFileDirectory(path);
            // Ký tự phân cách đường dẫn thư mục
            Console.WriteLine(Path.DirectorySeparatorChar);
            // Ghép, nối đường dẫn
            path = Path.Combine("Dir1", "Dir2", "TenFile.txt");
            // Thay đổi định dạng file, phần mở rộng của tên file
            path = Path.ChangeExtension(path, "md");
            Console.WriteLine(path);
            // Lấy ra thư mục chứa file theo path
            Console.WriteLine(Path.GetDirectoryName(path));
            // Trả về phần mở rộng
            Console.WriteLine(Path.GetExtension(path));
            // Trả về tên file
            Console.WriteLine(Path.GetFileName(path));
            // Trả về đường dẫn đầy đủ (tuyệt đối) của path
            Console.WriteLine(Path.GetFullPath(path));
            // Trả về 1 file ngẫu nhiên
            //path = Path.GetRandomFileName();
            //Console.WriteLine(path);
            // Tạo ra 1 file tạm thời -> Có thể xóa sau các phiên làm việc
            //path = Path.GetTempFileName();
            //Console.WriteLine(path);
            path = @"C:\Users\Daica\AppData\Local\Temp\tmpCD50.tmp";
            // File
            string filename = "text.txt";
            string content = "Xin chào các bạn 2020";
            // Ghi đè dữ liệu vào file
            //File.WriteAllText(filename, content); 
            // Ghi thêm nội dung vào file đã có dữ liệu trước đó
            // File.AppendAllText(filename, content);
            // Đọc file
            // content = File.ReadAllText(filename);
            // Console.WriteLine(content);
            // Di chuyển hoặc đổi tên file
            //File.Move("text.txt", "123.txt");
            // Copy file -> file mới
            // File.Copy("123.txt", "456.txt");
            // Xóa file
            // File.Delete("456.txt");

            // File Stream
            path = "data.txt";
            using (var stream = new FileStream(path: path, FileMode.Open))
            {
                // // Lưu dữ liệu
                // byte[] buffer = { 1, 2, 3 };
                // int offset = 0;
                // int count = 3;
                // stream.Write(buffer, offset, count);
                // // Đọc dữ liệu
                // int soByteDocDuoc = stream.Read(buffer, offset, count);

                // // int, double, -> bytes
                // int abc = 1;
                // var byte_abc = BitConverter.GetBytes(abc);
                // // bytes -> int, double,
                // BitConverter.ToInt32(byte_abc, 0);

                // string s = "Abc";
                // var bytes_s = Encoding.UTF8.GetBytes(s);

                // string aa = Encoding.UTF8.GetString(bytes_s, 0, 3);
                // Console.WriteLine(aa);

                // 
                Product product = new Product()
                {
                    ID = 10,
                    Price = 12345,
                    Name = "Sản phẩm 1"
                };
                //product.Save(stream);
                // Phục hồi dữ liệu đã lưu
                Product product1 = new Product();
                try
                {
                    product1.Restore(stream);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"{product1.Name} - {product1.Price} - {product1.ID}");
            }
        }
    }
}
