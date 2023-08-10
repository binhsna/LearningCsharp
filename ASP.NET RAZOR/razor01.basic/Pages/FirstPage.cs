using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
public class FirstPageModel : PageModel
{
    // Khai báo thuộc tính title
    public string title { set; get; } = "DAY LA TRANG RAZOR CUA BINHBOONG";

    // OnGet, OnGetAbc, OnGetXyz ...
    // OnPost(), OnPostAbc() ...
    // Handler

    public void OnGet()
    {
        Console.WriteLine("Truy van GET");
        ViewData["myData"] = "BinhNC.NET 2021";
    }
    // GET, Url?handler=Xyz
    public void OnGetXyz()
    {
        Console.WriteLine("Truy van GETXyz");
        ViewData["myData"] = "BinhNC.NET 2021 XYZ";
    }
    public string Welcome(string name)
    {
        return $"Chao mung {name} den voi website";
    }
}