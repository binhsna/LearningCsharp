using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ADO_02_SqlCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            // SQL Server
            var sqlStringBuilder = new SqlConnectionStringBuilder();
            sqlStringBuilder["Server"] = "localhost,1433";
            sqlStringBuilder["Database"] = "xtlab";
            sqlStringBuilder["UID"] = "sa";
            sqlStringBuilder["PWD"] = "123";

            var sqlStringConnection = sqlStringBuilder.ToString();
            // Console.WriteLine(sqlStringConnection);
            // string sqlconnectStr = "Data Source=localhost,1433;Initial Catalog=xtlab;User ID=sa;Password=123";
            using var connection = new SqlConnection(sqlStringConnection);
            connection.Open();
            // Truy vấn ...
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT DanhmucID, TenDanhMuc, MoTa FROM Danhmuc WHERE DanhmucID >= @DanhmucID";
            // var danhmucid = new SqlParameter("@DanhmucID", 5);
            // command.Parameters.Add(danhmucid);
            var danhmucid = command.Parameters.AddWithValue("@DanhmucID", 5);
            danhmucid.Value = 3;

            // command.ExecuteReader(); -> Dùng khi kết quả trả về có nhiều dòng

            // using var sqlreader = command.ExecuteReader();

            // var datatable = new DataTable();
            // datatable.Load(sqlreader);

            // if (sqlreader.HasRows)
            // {
            //     while (sqlreader.Read())
            //     {
            //         var id = sqlreader.GetInt32(0);
            //         var ten = sqlreader["TenDanhMuc"];
            //         var mota = sqlreader[2];
            //         Console.WriteLine($"{id} - {ten} - {mota}");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Không có dữ liệu");
            // }

            // command.ExecuteScalar(); -> Trả về 1 giá trị (dòng 1, cột 1)

            // command.CommandText = "SELECT COUNT(1) FROM Sanpham";
            // var returnValue = command.ExecuteScalar();
            // Console.WriteLine(returnValue);

            // command.ExecuteNonQuery(); -> Trả về tổng số dòng bị tác động bởi câu truy vấn đó
            // -> Insert, Update, Delete

            // command.CommandText = "INSERT into Shippers(Hoten, Sodienthoai)VALUES(@Hoten, @Sodienthoai)";
            // var hoten = command.Parameters.AddWithValue("@Hoten", "Nguyễn Công Bình");
            // var sodienthoai = command.Parameters.AddWithValue("@Sodienthoai", "0971912776");

            // var kq = command.ExecuteNonQuery();
            // Console.WriteLine(kq);

            // STORED PROCEDURE
            // using var cmd = new SqlCommand();
            // cmd.Connection = connection;
            // cmd.CommandText = "GetProductInfo";
            using var cmd = new SqlCommand("GetProductInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            var id = new SqlParameter("@id", SqlDbType.Int);
            cmd.Parameters.Add(id);
            id.Value = 3;
            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var tensp = reader[0];
                var tendm = reader["TenDanhMuc"];
                Console.WriteLine($"{tensp} - {tendm}");
            }
            connection.Close();
        }
    }
}
