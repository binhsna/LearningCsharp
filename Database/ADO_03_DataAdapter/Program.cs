using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
// dotnet add package System.Data.SqlClient -> Thư viện hỗ trợ kết nối đến SQL Server
// dotnet add package MySql.Data -> MySQL
namespace ADO_03_DataAdapter
{
    class Program
    {
        static void showDataTable(DataTable table)
        {
            Console.WriteLine($"Tên bảng: {table.TableName}");
            Console.Write($"{"Index",15}");
            foreach (DataColumn c in table.Columns)
            {
                Console.Write($"{c.ColumnName,15}");
            }
            Console.WriteLine();

            int number_cols = table.Columns.Count;
            int index = 0;

            foreach (DataRow r in table.Rows)
            {
                Console.Write($"{index,15}");
                for (int i = 0; i < number_cols; i++)
                {
                    Console.Write($"{r[i],15}");
                    // Console.Write($"{r[0],20}");
                    // Console.Write($"{r["HoTen"],20}");
                    // Console.Write($"{r["Tuoi"],20}");
                }
                Console.WriteLine();
                index++;
            }
        }
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

            using var connection = new SqlConnection(sqlStringConnection);
            connection.Open();

            // var dataset = new DataSet();
            // // dataset.Tables -> dataset: Tập dữ liệu
            // var table = new DataTable("MyTable");
            // dataset.Tables.Add(table);

            // table.Columns.Add("STT");
            // table.Columns.Add("HoTen");
            // table.Columns.Add("Tuoi");

            // table.Rows.Add(1, "Nguyen Van A", 25);
            // table.Rows.Add(2, "Nguyen Van B", 21);
            // table.Rows.Add(3, "Nguyen Van C", 20);

            // DataAdapter -> Cầu nối ánh xạ giữa dữ liệu thật (cơ sở dữ liệu SQL Server) với dataset
            // -> Bảng trong SQL Server sẽ được ánh xạ trong DataTable
            var adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "Nhanvien");
            // SelectCommand
            adapter.SelectCommand = new SqlCommand("SELECT NhanviennID, Ten, Ho FROM Nhanvien", connection);
            // InsertCommand
            adapter.InsertCommand = new SqlCommand("INSERT INTO Nhanvien(Ho, Ten)VALUES(@Ho, @Ten)", connection);
            adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");
            // DeleteCommand
            adapter.DeleteCommand = new SqlCommand("DELETE FROM Nhanvien WHERE NhanviennID = @NhanviennID", connection);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
            pr1.SourceColumn = "NhanviennID";
            pr1.SourceVersion = DataRowVersion.Original;
            // UpdateCommand
            adapter.UpdateCommand = new SqlCommand("UPDATE Nhanvien SET Ho = @Ho, Ten = @Ten WHERE NhanviennID = @NhanviennID", connection);
            adapter.UpdateCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.UpdateCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
            pr2.SourceColumn = "NhanviennID";
            pr2.SourceVersion = DataRowVersion.Original;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            DataTable table = dataSet.Tables["Nhanvien"];
            // showDataTable(table);

            // var row = table.Rows.Add();
            // row["Ten"] = "Bình";
            // row["Ho"] = "Nguyễn Công";

            // Cập nhật

            // var row10 = table.Rows[10];
            // row10.Delete();

            var row9 = table.Rows[9];
            row9["Ten"] = "Anh";

            adapter.Update(dataSet);

            showDataTable(table);

            connection.Close();

        }
    }
}
