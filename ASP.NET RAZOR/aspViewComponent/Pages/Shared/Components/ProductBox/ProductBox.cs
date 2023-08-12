
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace binhLab
{
    // [ViewComponent]
    public class ProductBox : ViewComponent
    {
        // (1)
        // Invoke(object m); -> Phải trả về kiểu string / (IViewComponentResult)
        // InvokeAsync();

        // (2)
        /*
            - [ViewComponent]
            - Hoặc đặt tên lớp có hậu tố ViewComponent
            * Hoặc là kế thừa từ ViewComponent
        */
        ProductListService productService;
        public ProductBox(ProductListService _products)
        {
            productService = _products;
        }
        public IViewComponentResult Invoke(bool sapxeptang = true)
        {
            // return View(); // Mặc định thi hành Default.cshtml
            // return View("Default1"); // Tên View là Default1.cshtml
            // return View<string>("Thiết lập model"); // Default.cshtml
            //
            List<Product> _products = null;
            if (sapxeptang)
            {
                _products = productService.products.OrderBy(p => p.Price).ToList();
            }
            else
            {
                _products = productService.products.OrderByDescending(p => p.Price).ToList();
            }

            return View<List<Product>>(_products); // Default.cshtml
        }
    }
}