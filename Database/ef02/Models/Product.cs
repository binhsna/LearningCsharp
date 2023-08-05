using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ef02
{
    // [Table("Product")]
    public class Product
    {
        // [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Tensanpham", TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        // Reference Navigation
        // Cách tạo ra FOREIGN KEY
        // [ForeignKey("CategoryId")]
        // [Required]
        public virtual Category Category { get; set; } // FK -> PK CategoryId

        // Một sản phẩm nếu thuộc 2 Category thì sao?
        public int? CategoryId2 { get; set; }
        // [ForeignKey("CategoryId2")]
        // [InverseProperty("Products")]
        public virtual Category Category2 { get; set; }
        public void PrintInfo() => Console.WriteLine($"{ProductId} - {Name} - {Price} - {CategoryId}");
    }
}
/*
    Table("TableName") -> Model nào đó tương ứng với 1 bảng ở trên database
    [Key] -> Primary Key (PK)
    [Required] -> not null
    [StringLength(50)] -> string -> nvarchar(50)
    [Column(TypeName = "money")] -> Chỉ định kiểu trường dữ liệu tương ứng trên database
    [Column("Tensanpham", TypeName = "nvarchar(50)")] -> Còn chỉ rõ thêm tên trường dữ liệu
    [ForeignKey("CategoryId")] -> Thiết lập khóa ngoại

    Reference Navigation -> ForeignKey (1 - nhiều)
                            1 - 1
    Collection Navigation -> (Không tạo ForeignKey)

    InverseProperty

*/