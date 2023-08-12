using System.Collections.Generic;

namespace binhLab
{
    public class ProductListService
    {
        public List<Product> products { set; get; } = new List<Product>(){
                new Product() { Name = "SP 1", Description = "Mô tả cho SP 1", Price = 300 },
                new Product() { Name = "SP 2", Description = "Mô tả cho SP 2", Price = 200 },
                new Product() { Name = "SP 3", Description = "Mô tả cho SP 3", Price = 500 }
            };
    }
}