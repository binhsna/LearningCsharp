#pragma checksum "D:\Projects\LearningCsharp\ASP.NET RAZOR\layoutRazor\Pages\Post1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41ffe396df0f40a1a82f60a284c51a7918edf8d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(layoutRazor.Pages.Pages_Post1), @"mvc.1.0.razor-page", @"/Pages/Post1.cshtml")]
namespace layoutRazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projects\LearningCsharp\ASP.NET RAZOR\layoutRazor\Pages\_ViewImports.cshtml"
using layoutRazor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41ffe396df0f40a1a82f60a284c51a7918edf8d5", @"/Pages/Post1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f8dc38204bbeb5d2353ac3c0ddb8cdadae49a94", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Post1 : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Projects\LearningCsharp\ASP.NET RAZOR\layoutRazor\Pages\Post1.cshtml"
  
    ViewData["Title"] = "POST1";
    Layout = "_PostLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ĐÂY LÀ POST1</h1>\r\n");
            DefineSection("FooterContent", async() => {
                WriteLiteral("\r\n    <p>Bài viết liên quan POST1</p>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PrivacyModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PrivacyModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PrivacyModel>)PageContext?.ViewData;
        public PrivacyModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591