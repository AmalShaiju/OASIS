#pragma checksum "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c55882ba7cf4554a19af7cd1b28d98d38c1fd386"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roles_Delete), @"mvc.1.0.view", @"/Views/Roles/Delete.cshtml")]
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
#line 1 "C:\Users\Asus\Source\Repos\OASIS\Views\_ViewImports.cshtml"
using OASIS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asus\Source\Repos\OASIS\Views\_ViewImports.cshtml"
using OASIS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c55882ba7cf4554a19af7cd1b28d98d38c1fd386", @"/Views/Roles/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_Roles_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OASIS.Models.Role>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/details.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/user-full-fill.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right; width:17%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div style=\"padding: 0% 10% 0% 3%;\">\r\n    <div class=\"details-headings row\" style=\"margin-bottom:2%;\">\r\n        <div style=\"width:50px;height:50px; margin-top: 0.8%;\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c55882ba7cf4554a19af7cd1b28d98d38c1fd3867188", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div style=\"margin-left:1.8%;margin-left: 1.8%;display: flex;align-self: center;\">\r\n            <h2 style=\"color:#7460ee\">");
#nullable restore
#line 14 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                                 Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        </div>\r\n\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c55882ba7cf4554a19af7cd1b28d98d38c1fd3868728", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 18 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <div>

        <div class=""row details-container"">
            <div class=""col-6 col-md-4 row inner-details-container-one"">
                <div class=""container"">
                    <div class=""details-headings"" style=""justify-content: center;"">
                        <div class=""details-headings-img-container"">
                            <img src=""/resources/project-alt.png"" alt=""Alternate Text"" />
                        </div>
                        <div>
                            <h3>Employees</h3>
                        </div>
                    </div>

                    <div class=""row"" style="" text-align: center; margin-top: 8%; height:90%; display:block;"">
");
#nullable restore
#line 36 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                         foreach (var item in Model.Employees)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div style=\"width:100%; height:11%;\">\r\n                                <p>\r\n\r\n                                    ");
#nullable restore
#line 41 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                               Write(Html.DisplayFor(model => item.FormalName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                                </p>\r\n                            </div>\r\n");
#nullable restore
#line 46 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>



            </div>
            <div class=""col-12 col-md-8 row inner-details-container-two"">

                <div class=""container"">

                    <div class=""details-headings row"" style=""margin-bottom:0px;"">
                        <div class=""details-headings-img-container"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c55882ba7cf4554a19af7cd1b28d98d38c1fd38612381", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <div>
                            <h3>Role Information</h3>
                        </div>
                    </div>
                    <hr />


                    <div class=""row"">
                        <div class=""col"">
                            <label>
                                ");
#nullable restore
#line 71 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 77 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                           Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 83 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                           Write(Html.DisplayNameFor(model => model.LabourCostPerHr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 89 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                           Write(Html.DisplayFor(model => model.LabourCostPerHr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 95 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                           Write(Html.DisplayNameFor(model => model.LabourPricePerHr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 101 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
                           Write(Html.DisplayFor(model => model.LabourPricePerHr));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style=""display:flex; margin-top:50px; margin-bottom:20px;"">
        <div style=""width:10%"" class=""button-menu form-group btn btn-danger"">
            <div style=""width:22px; height:25px;"">
                <svg version=""1.0"" xmlns=""http://www.w3.org/2000/svg""
                     width=""512.000000pt"" height=""512.000000pt"" viewBox=""0 0 512.000000 512.000000""
                     preserveAspectRatio=""xMidYMid meet"">

                    <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)""
                       fill=""white"" stroke=""none"">
                        <path d=""M2115 5101 c-123 -45 -208 -118 -260 -224 -46 -95 -55 -149 -55 -343
                                            l0 -164 -600 0 -600 0 0 -305 0 -305 1960 0 1960 0 0 305 0 305 -600 0 -600 0
                                            0 164 c");
            WriteLiteral(@"0 194 -9 248 -55 343 -43 87 -121 163 -215 207 l-65 31 -410 2 c-376 3
                                            -414 1 -460 -16z m823 -313 c60 -37 72 -79 72 -260 l0 -158 -450 0 -450 0 0
                                            155 c0 180 11 221 69 261 l36 24 344 0 c334 0 345 -1 379 -22z"" />
                        <path d=""M926 3438 c2 -18 63 -710 134 -1538 72 -828 135 -1526 140 -1553 31
                                            -149 153 -282 302 -329 57 -17 115 -18 1058 -18 943 0 1001 1 1058 18 149 47
                                            271 180 302 329 5 27 68 725 140 1553 71 828 132 1520 134 1538 l5 32 -1639 0
                                            -1639 0 5 -32z m1174 -1553 l0 -825 -145 0 -145 0 0 825 0 825 145 0 145 0 0
                                            -825z m610 0 l0 -825 -150 0 -150 0 0 825 0 825 150 0 150 0 0 -825z m600 0
                                            l0 -825 -145 0 -145 0 0 825 0 825 145 0 145 0 0 -825z"" />
                    </g>
                ");
            WriteLiteral("</svg>\r\n            </div>\r\n            <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c55882ba7cf4554a19af7cd1b28d98d38c1fd38618675", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c55882ba7cf4554a19af7cd1b28d98d38c1fd38618954", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 136 "C:\Users\Asus\Source\Repos\OASIS\Views\Roles\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <input type=\"submit\" value=\"Delete\" style=\" width:100%;\">\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n        <div style=\"width:90%;\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c55882ba7cf4554a19af7cd1b28d98d38c1fd38622002", async() => {
                WriteLiteral("\r\n\r\n                &#8592; Back To List\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OASIS.Models.Role> Html { get; private set; }
    }
}
#pragma warning restore 1591
