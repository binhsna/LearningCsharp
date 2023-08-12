using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using binhLab;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace aspViewComponent.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            var username = this.Request.Form["username"];

            var message = new MessagePage.Message
            {
                title = "Thông báo",
                htmlcontent = $"Cảm ơn {username} đã gửi thông tin",
                secondwait = 7,
                urlredirect = Url.Page("Privacy")
            };
            return ViewComponent("MessagePage", message);
        }
        // public IActionResult OnGet()
        // {
        //     // PageModel: Partial
        //     // Controller: PartialView
        //     // return Partial("_Message");
        //     return ViewComponent("ProductBox", false);
        // }

    }
}
