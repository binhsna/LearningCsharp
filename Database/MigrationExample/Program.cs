using System;
using EFMigration.Models;
/*
dotnet add package System.Data.SqlClient
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Logging.Console
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
*/
namespace EFMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            // migration: code => database
            // webdb

            /*
            
            dotnet ef migrations add NameMigration
            dotnet ef migrations list
            dotnet ef migrations remove

            dotnet ef migrations script -o migration.sql
            dotnet ef migrations script MigrationV1 MigrationV2


            dotnet ef database update [MigrationName]
            dotnet ef database drop -f

            */
        }
    }
}
