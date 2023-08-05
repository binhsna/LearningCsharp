using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ef02
{
    public class CategoryDetail
    {
        public int CategoryDetailId { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int CountProduct { get; set; }

        public Category category { get; set; }
    }
}
/*

*/