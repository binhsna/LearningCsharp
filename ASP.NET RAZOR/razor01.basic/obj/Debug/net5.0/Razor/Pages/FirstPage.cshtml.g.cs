#pragma checksum "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fe016679cdd4dfb7fc50ac5ed8db0ebdf6fa6b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_FirstPage), @"mvc.1.0.razor-page", @"/Pages/FirstPage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/trang-dau-tien/{soLanLap:int?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fe016679cdd4dfb7fc50ac5ed8db0ebdf6fa6b0", @"/Pages/FirstPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ea78ee065d0207bec354c5dd51e4024d2da4441", @"/Pages/_ViewImports.cshtml")]
    public class Pages_FirstPage : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "SecondPage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
  
    Layout = "_MyLayout";
    ViewData["title"] = "TRANG DAU TIEN";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 style=\"color: red;\">");
#nullable restore
#line 7 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
                   Write(Model.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            WriteLiteral("<h2>");
#nullable restore
#line 11 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
Write(ViewData["myData"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<p>Học lập trình ASP.NET Core (<strong>");
#nullable restore
#line 12 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
                                  Write(System.DateTime.Now);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>)</p>\r\n\r\n");
#nullable restore
#line 14 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
  
    var a = 2;
    int b = 3;

    var soLanLapString = this.Request.RouteValues["soLanLap"]??"0";

    int soLanLap = Int32.Parse(soLanLapString.ToString());


#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Căn bậc hai của ");
#nullable restore
#line 22 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
                  Write(a);

#line default
#line hidden
#nullable disable
            WriteLiteral(" là ");
#nullable restore
#line 22 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
                        Write(Math.Sqrt(a));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<p>Tổng của ");
#nullable restore
#line 48 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
       Write(a);

#line default
#line hidden
#nullable disable
            WriteLiteral(" và ");
#nullable restore
#line 48 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
             Write(b);

#line default
#line hidden
#nullable disable
            WriteLiteral(" là ");
#nullable restore
#line 48 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
                    Write(a + b);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<p>Số lần lặp là ");
#nullable restore
#line 50 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
            Write(soLanLap);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<ol>\r\n");
#nullable restore
#line 52 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
     for (int i = 0; i <= soLanLap; i++)
    {
        // ...

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>Mục thứ ");
#nullable restore
#line 55 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 56 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ol>\r\n\r\n<p>");
#nullable restore
#line 59 "D:\Projects\LearningCsharp\ASP.NET RAZOR\razor01.basic\Pages\FirstPage.cshtml"
Write(Model.Welcome("Nguyen Cong Binh"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fe016679cdd4dfb7fc50ac5ed8db0ebdf6fa6b07008", async() => {
                WriteLiteral("Trang thứ 2");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FirstPageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<FirstPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<FirstPageModel>)PageContext?.ViewData;
        public FirstPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
