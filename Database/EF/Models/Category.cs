using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EF
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        // Collection Navigation (Điều hướng tập hợp)
        public virtual List<Product> Products { get; set; }
    }
}
/*

*/