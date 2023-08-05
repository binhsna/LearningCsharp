using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef02
{
    public class ShopContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
         {
             builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
             // builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
             builder.AddConsole();
         });
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryDetail> CategoryDetail { get; set; }

        private const string connectionString = @"
        Data Source=localhost,1433;
        Initial Catalog=shopdata;
        User ID=sa;Password=123";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            // optionsBuilder.UseLazyLoadingProxies();
            // Console.WriteLine("OnConfiguring");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API
            // Console.WriteLine("OnModelCreating");
            /*
            var entity = modelBuilder.Entity(typeof(Product));
            // entity => Fluent API - Product

            var entity = modelBuilder.Entity<Product>();
            */
            modelBuilder.Entity<Product>(entity =>
            {
                // entity => Fluent API
                // Table mapping: Ánh xạ của bảng
                entity.ToTable("Product");
                // Primary key
                entity.HasKey(p => p.ProductId);
                // Index - Đánh chỉ mục -> Tăng tốc độ truy vấn, tìm kiếm
                entity.HasIndex(p => p.Price)
                      .HasDatabaseName("index-product-price");
                // Relative
                entity.HasOne(p => p.Category)
                      .WithMany()                   // Category không có Property ~ Product
                      .HasForeignKey("CategoryId") // Đặt tên Foreign Key
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("Khoa_ngoai_product_category");

                // Tạo khóa ngoại 2, một sản phẩm có thể thuộc vào 2 category
                entity.HasOne(p => p.Category2)
                                .WithMany(c => c.Products)  // Collection Navigation
                                .HasForeignKey("CategoryId2")
                                .OnDelete(DeleteBehavior.NoAction)
                                .HasConstraintName("Khoa_ngoai_product_category2");

                // Thiết lập các trường dữ liệu
                entity.Property(p => p.Name)
                      .HasColumnName("title")  // Tên trường tương ứng trong database
                      .HasColumnType("nvarchar")
                      .HasMaxLength(60)
                      .IsRequired(true)
                      .HasDefaultValue("Tên sản phẩm mặc định");

            });

            // Mối quan hệ 1 - 1
            modelBuilder.Entity<CategoryDetail>(entity =>
            {
                entity.HasOne(d => d.category)
                .WithOne(c => c.categoryDetail)
                .HasForeignKey<CategoryDetail>(c => c.CategoryDetailId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}