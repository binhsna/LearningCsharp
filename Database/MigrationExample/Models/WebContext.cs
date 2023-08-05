using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFMigration.Models
{
    public class WebContext : DbContext
    {
        public DbSet<Article> articles { set; get; }        // bảng article
        public DbSet<Tag> tags { set; get; }                // bảng tag
        public DbSet<ArticleTag> ArticleTags { set; get; }

        // chuỗi kết nối với tên db sẽ làm  việc đặt là webdb
        public const string ConnectStrring = @"Data Source=localhost,1433;Initial Catalog=webdb;User ID=sa;Password=123";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectStrring);
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());       // bật logger
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasIndex(articleTag => new { articleTag.ArticleId, articleTag.TagId })
                .IsUnique();
            });
        }
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                    builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                    LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }

    }

}