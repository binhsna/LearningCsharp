using System;

namespace testScaffold
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet ef dbcontext scaffold -o Models -d "sqlConnectString" "Microsoft.EntityFrameworkCore.SqlServer"
            // "Data Source=localhost,1433;Initial Catalog=xtlab;User ID=sa;Password=123"
            // dotnet ef dbcontext scaffold -o Models -d "Data Source=localhost,1433;Initial Catalog=xtlab;User ID=sa;Password=123" "Microsoft.EntityFrameworkCore.SqlServer"


        }
    }
}
