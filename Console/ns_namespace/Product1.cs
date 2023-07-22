using System;

namespace SanPham
{
    public partial class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public string GetInfor()
        {
            return $"{name} / {price} : {description} - {manufactory.name}";
        }
        public partial void myMethod();
    }
}