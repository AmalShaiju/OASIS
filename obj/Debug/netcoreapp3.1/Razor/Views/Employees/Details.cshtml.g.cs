#pragma checksum "C:\OASIS\Views\Employees\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "066e8a1dfef80b6217e9f7cb8bc11d1495b0491f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_Details), @"mvc.1.0.view", @"/Views/Employees/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"066e8a1dfef80b6217e9f7cb8bc11d1495b0491f", @"/Views/Employees/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OASIS.Models.Employee>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/details.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_DetailsMenu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "projects", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/user-full-fill.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/location.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\OASIS\Views\Employees\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div style=\"padding: 0% 10% 0% 3%;\">\r\n    <div class=\"details-headings row\" style=\"margin-bottom:2%;\">\r\n        <div style=\"width:50px;height:50px; margin-top: 0.8%;\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "066e8a1dfef80b6217e9f7cb8bc11d1495b0491f6857", async() => {
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
            WriteLiteral("\r\n        </div>\r\n        <div style=\"margin-left:1.8%;\">\r\n            <h2 style=\"color:#7460ee\">");
#nullable restore
#line 14 "C:\OASIS\Views\Employees\Details.cshtml"
                                 Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <p>");
#nullable restore
#line 15 "C:\OASIS\Views\Employees\Details.cshtml"
          Write(Model.Role.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p>\r\n        </div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "066e8a1dfef80b6217e9f7cb8bc11d1495b0491f8529", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "066e8a1dfef80b6217e9f7cb8bc11d1495b0491f9674", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 21 "C:\OASIS\Views\Employees\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
                        <h3 style=""margin-bottom: 0px; font-size: 23px;"">Projects Worked</h3>
                    </div>
                </div>

                <div class=""row"" style="" text-align: center; margin-top: 8%; height:90%; display:block;"">
");
#nullable restore
#line 39 "C:\OASIS\Views\Employees\Details.cshtml"
                     foreach (var item in ViewBag.ProjectName)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div style=\"width:100%; height:12%;\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "066e8a1dfef80b6217e9f7cb8bc11d1495b0491f12300", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 43 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\OASIS\Views\Employees\Details.cshtml"
                                                                                WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        </div>\r\n");
#nullable restore
#line 47 "C:\OASIS\Views\Employees\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>



        </div>
        <div class=""col-12 col-md-8 row inner-details-container-two"">

            <div class=""container"">
                <div class=""accordion"" id=""accordionExample"">
                    <div class=""card"">
                        <div class=""card-header"" id=""headingOne"">
                            <h2 class=""mb-0"">
                                <button class=""collapse-card"" style="" color: #7460ee;"" type=""button"" data-toggle=""collapse"" data-target=""#collapseOne"" aria-expanded=""true"" aria-controls=""collapseOne"">
                                    <div class=""details-headings row"" style=""margin-bottom:0px;"">
                                        <div class=""details-headings-img-container"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "066e8a1dfef80b6217e9f7cb8bc11d1495b0491f16078", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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
                                            <h3>Personal Information </h3>
                                        </div>
                                        <div style="" margin-left: 1.5%; margin-top: 0.5%;"">
                                            <svg xmlns=""http://www.w3.org/2000/svg"" height=""24"" viewBox=""0 0 24 24"" width=""24""><path d=""M0 0h24v24H0z"" fill=""none"" /><path d=""M16.59 8.59L12 13.17 7.41 8.59 6 10l6 6 6-6z"" /></svg>
                                        </div>
                                    </div>
                                    <hr />
                                </button>
                            </h2>
                        </div>

                        <div id=""collapseOne"" class=""collapse show"" aria-labelledby=""headingOne"" data-parent=""#accordionExample"">
                            <div class=""card-body"">
                                <div class=""row""");
            WriteLiteral(">\r\n                                    <div class=\"col\">\r\n                                        <label>\r\n                                            ");
#nullable restore
#line 83 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 89 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 95 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 101 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 108 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 114 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 121 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Role.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 127 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.Role.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>

                                            ");
#nullable restore
#line 135 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 140 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 147 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 153 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.Email));

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
                    <div class=""card"">
                        <div class=""card-header"" id=""headingTwo"">
                            <h2 class=""mb-0"">
                                <button class=""collapse-card collapsed"" style="" color: #7460ee; "" type=""button"" data-toggle=""collapse"" data-target=""#collapseTwo"" aria-expanded=""true"" aria-controls=""collapseTwo"">
                                    <div class=""details-headings row"" style=""margin-bottom:0px;"">
                                        <div class=""details-headings-img-container"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "066e8a1dfef80b6217e9f7cb8bc11d1495b0491f25289", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
                                            <h3>Address Information</h3>
                                        </div>
                                        <div style="" margin-left: 1.5%; margin-top: 0.5%;"">
                                            <svg xmlns=""http://www.w3.org/2000/svg"" height=""24"" viewBox=""0 0 24 24"" width=""24""><path d=""M0 0h24v24H0z"" fill=""none"" /><path d=""M16.59 8.59L12 13.17 7.41 8.59 6 10l6 6 6-6z"" /></svg>
                                        </div>
                                    </div>
                                    <hr />

                                </button>
                            </h2>
                        </div>

                        <div id=""collapseTwo"" class=""collapse"" aria-labelledby=""headingTwo"" data-parent=""#accordionExample"">
                            <div class=""card-body"">
                                <div class=""row"">
  ");
            WriteLiteral("                                  <div class=\"col\">\r\n                                        <label>\r\n                                            ");
#nullable restore
#line 187 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.AddressLineOne));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 193 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.AddressLineOne));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 200 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.AddressLineTwo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 206 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.AddressLineTwo));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 213 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.ApartmentNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 219 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.ApartmentNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 226 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 232 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 239 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Province));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 245 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.Province));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </p>
                                    </div>
                                    <div class=""w-100""></div>
                                    <div class=""col"">
                                        <label>
                                            ");
#nullable restore
#line 252 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </label>\r\n                                    </div>\r\n                                    <div class=\"col\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 258 "C:\OASIS\Views\Employees\Details.cshtml"
                                       Write(Html.DisplayFor(model => model.Country));

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
            </div>
        </div>
    </div>
</div>




");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 277 "C:\OASIS\Views\Employees\Details.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("    <script type=\"text/javascript\">\r\n        $(\'a[data-toggle=\"tab\"]\').on(\'shown.bs.tab\', function (e) {\r\n            e.target // newly activated tab\r\n            e.relatedTarget // previous active tab\r\n        })\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OASIS.Models.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
