#pragma checksum "D:\Projects\LearningCsharp\ASP.NET RAZOR\aspViewComponent\Pages\Shared\_Message.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f91a9739043379d5ec14bb293a7f4ecdc3090253"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(aspViewComponent.Pages.Shared.Pages_Shared__Message), @"mvc.1.0.view", @"/Pages/Shared/_Message.cshtml")]
namespace aspViewComponent.Pages.Shared
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
#line 1 "D:\Projects\LearningCsharp\ASP.NET RAZOR\aspViewComponent\Pages\_ViewImports.cshtml"
using aspViewComponent;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f91a9739043379d5ec14bb293a7f4ecdc3090253", @"/Pages/Shared/_Message.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2deffb0acb58fcecee1b42f2905f03394477a782", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__Message : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Projects\LearningCsharp\ASP.NET RAZOR\aspViewComponent\Pages\Shared\_Message.cshtml"
  
    var title = ViewData["titleMessage"] ?? "THÔNG BÁO";
    var content = ViewData["content"] ?? "Nội dung thông báo";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"alert alert-danger\">\r\n    <strong>");
#nullable restore
#line 6 "D:\Projects\LearningCsharp\ASP.NET RAZOR\aspViewComponent\Pages\Shared\_Message.cshtml"
       Write(title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br>\r\n    ");
#nullable restore
#line 7 "D:\Projects\LearningCsharp\ASP.NET RAZOR\aspViewComponent\Pages\Shared\_Message.cshtml"
Write(content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591