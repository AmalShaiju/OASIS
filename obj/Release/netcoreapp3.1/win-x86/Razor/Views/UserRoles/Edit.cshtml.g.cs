#pragma checksum "C:\OASIS\Views\UserRoles\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c8d565924176493b0e3b366b7bb7b0610a718cce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserRoles_Edit), @"mvc.1.0.view", @"/Views/UserRoles/Edit.cshtml")]
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
#nullable restore
#line 1 "C:\OASIS\Views\_ViewImports.cshtml"
using OASIS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\OASIS\Views\_ViewImports.cshtml"
using OASIS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8d565924176493b0e3b366b7bb7b0610a718cce", @"/Views/UserRoles/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_UserRoles_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OASIS.ViewModels.PageClaims>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/updateClaim.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "C:\OASIS\Views\UserRoles\Edit.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n\r\n");
#nullable restore
#line 12 "C:\OASIS\Views\UserRoles\Edit.cshtml"
         foreach (var i in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""card col-4 mb-5"" style=""width: 18rem; display:flex;border-top-left-radius: 25px; border-top-right-radius: 25px;"">
                <div class=""card-header"" style="" border-top-left-radius: 25px; border-top-right-radius: 25px;"">
                    <h5> ");
#nullable restore
#line 16 "C:\OASIS\Views\UserRoles\Edit.cshtml"
                    Write(i.PageName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                </div>\r\n                <ul class=\"list-group list-group-flush\">\r\n");
#nullable restore
#line 19 "C:\OASIS\Views\UserRoles\Edit.cshtml"
                     foreach (var item in i.Claims)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item row mr-3 ml-3\" style=\"display:flex\">\r\n                            <label class=\"col-10\" style=\"align-self:center\">\r\n                                ");
#nullable restore
#line 23 "C:\OASIS\Views\UserRoles\Edit.cshtml"
                           Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </label>\r\n                            <div class=\"col-2\">\r\n");
#nullable restore
#line 26 "C:\OASIS\Views\UserRoles\Edit.cshtml"
                                 if (item.Value == "True")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <input type=\"checkbox\"");
            BeginWriteAttribute("id", " id=\"", 1105, "\"", 1144, 5);
#nullable restore
#line 28 "C:\OASIS\Views\UserRoles\Edit.cshtml"
WriteAttributeValue("", 1110, item.Type, 1110, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1120, "-", 1120, 1, true);
#nullable restore
#line 28 "C:\OASIS\Views\UserRoles\Edit.cshtml"
WriteAttributeValue("", 1121, item.Value, 1121, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1132, "-", 1132, 1, true);
#nullable restore
#line 28 "C:\OASIS\Views\UserRoles\Edit.cshtml"
WriteAttributeValue("", 1133, i.RoleName, 1133, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onchange=\"UpdateClaim(this)\" checked data-toggle=\"toggle\" data-onstyle=\"success\" data-offstyle=\"danger\">\r\n");
#nullable restore
#line 29 "C:\OASIS\Views\UserRoles\Edit.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <input type=\"checkbox\"");
            BeginWriteAttribute("id", " id=\"", 1418, "\"", 1457, 5);
#nullable restore
#line 32 "C:\OASIS\Views\UserRoles\Edit.cshtml"
WriteAttributeValue("", 1423, item.Type, 1423, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1433, "-", 1433, 1, true);
#nullable restore
#line 32 "C:\OASIS\Views\UserRoles\Edit.cshtml"
WriteAttributeValue("", 1434, item.Value, 1434, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1445, "-", 1445, 1, true);
#nullable restore
#line 32 "C:\OASIS\Views\UserRoles\Edit.cshtml"
WriteAttributeValue("", 1446, i.RoleName, 1446, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onchange=\"UpdateClaim(this)\" data-toggle=\"toggle\" data-onstyle=\"success\" data-offstyle=\"danger\">\r\n");
#nullable restore
#line 33 "C:\OASIS\Views\UserRoles\Edit.cshtml"

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </li>\r\n");
#nullable restore
#line 37 "C:\OASIS\Views\UserRoles\Edit.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n");
#nullable restore
#line 40 "C:\OASIS\Views\UserRoles\Edit.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-10\">\r\n\r\n        </div>\r\n        <div class=\"col-2\">\r\n            <a");
            BeginWriteAttribute("href", " href=\'", 1868, "\'", 1897, 1);
#nullable restore
#line 49 "C:\OASIS\Views\UserRoles\Edit.cshtml"
WriteAttributeValue("", 1875, ViewData["returnURL"], 1875, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-info"" style="" width: 50%; float: right;"">

                <!--?xml version=""1.0"" encoding=""iso-8859-1"" ?-->
                <!-- Generator: Adobe Illustrator 19.0.0, SVG Export Plug-In . SVG Version: 6.00 Build 0)  -->
                <svg version=""1.1"" id=""Capa_1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" x=""0px"" y=""0px"" viewBox=""0 0 512 512"" style=""enable-background:new 0 0 512 512;width: 32%;height: 100%;"" xml:space=""preserve"">
                <g fill=""#f8f9fa"">
                <path d=""M492,236H68.442l70.164-69.824c7.829-7.792,7.859-20.455,0.067-28.284c-7.792-7.83-20.456-7.859-28.285-0.068
			l-104.504,104c-0.007,0.006-0.012,0.013-0.018,0.019c-7.809,7.792-7.834,20.496-0.002,28.314c0.007,0.006,0.012,0.013,0.018,0.019
			l104.504,104c7.828,7.79,20.492,7.763,28.285-0.068c7.792-7.829,7.762-20.492-0.067-28.284L68.442,276H492
			c11.046,0,20-8.954,20-20C512,244.954,503.046,236,492,236z""></path>

	</g>
</svg>

            </a>
        </div>
  ");
            WriteLiteral("  </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 68 "C:\OASIS\Views\UserRoles\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8d565924176493b0e3b366b7bb7b0610a718cce10101", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OASIS.ViewModels.PageClaims>> Html { get; private set; }
    }
}
#pragma warning restore 1591
