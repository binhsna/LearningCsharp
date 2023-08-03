using System;
// dotnet add package System.Data.SqlClient -> Thư viện hỗ trợ kết nối đến SQL Server
// dotnet add package MySql.Data -> MySQL
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace ADO_01_SqlConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            // SQL Server
            // var sqlStringBuilder = new SqlConnectionStringBuilder();
            // sqlStringBuilder["Server"] = "localhost,1433";
            // sqlStringBuilder["Database"] = "xtlab";
            // sqlStringBuilder["UID"] = "sa";
            // sqlStringBuilder["PWD"] = "123";

            // var sqlStringConnection = sqlStringBuilder.ToString();
            // Console.WriteLine(sqlStringConnection);
            // // string sqlconnectStr = "Data Source=localhost,1433;Initial Catalog=xtlab;User ID=sa;Password=123";
            // using var connection = new SqlConnection(sqlStringConnection);
            // connection.Open();
            // Console.WriteLine(connection.State);
            // // Truy vấn ...
            // using DbCommand command = new SqlCommand();
            // command.Connection = connection;
            // command.CommandText = "SELECT TOP (5) * FROM Sanpham";

            // var datareader = command.ExecuteReader();
            // while (datareader.Read())
            // {
            //     Console.WriteLine($"{datareader["TenSanpham"],10} - Giá: {datareader["Gia"],8}");
            // }
            // connection.Close();

            // MySQL
            var sqlStringBuilder = new MySqlConnectionStringBuilder();
            sqlStringBuilder["Server"] = "localhost";
            sqlStringBuilder["Database"] = "xtlab";
            sqlStringBuilder["UID"] = "root";
            sqlStringBuilder["PWD"] = "MyBibo@bgdwQ";
            sqlStringBuilder["Port"] = "3306";


            var sqlStringConnection = sqlStringBuilder.ToString();
            Console.WriteLine(sqlStringConnection);

            using var connection = new MySqlConnection(sqlStringConnection);
            connection.Open();
            Console.WriteLine(connection.State);
            // Truy vấn ...
            using DbCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Sanpham Limit 0, 5";

            var datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Console.WriteLine($"{datareader["TenSanpham"],10} - Giá: {datareader["Gia"],8}");
            }
            connection.Close();
        }
    }
}