#pragma checksum "C:\OASIS\Views\Employees\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85a96bc61197fe29b6287ba4757471b1e8c3da50"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85a96bc61197fe29b6287ba4757471b1e8c3da50", @"/Views/Employees/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OASIS.Models.Employee>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/details.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/user-full-fill.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/location.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/editIcon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString(" width:100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/delet-fill-white.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85a96bc61197fe29b6287ba4757471b1e8c3da507857", async() => {
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
            WriteLiteral("\r\n        </div>\r\n        <div style=\"margin-left:1.8%\">\r\n            <h2 style=\"color:#7460ee\">");
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
            WriteLiteral("  </p>\r\n        </div>\r\n\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85a96bc61197fe29b6287ba4757471b1e8c3da509542", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 19 "C:\OASIS\Views\Employees\Details.cshtml"
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
                            <h3 style=""margin-bottom: 0px; font-size: 23px;"">Bids Designed</h3>
                        </div>
                    </div>

                    <div class=""row"" style="" text-align: center; margin-top: 8%;"">
");
            WriteLiteral("                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 39 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>
                        </div>
                        <div class=""w-100""></div>

                    </div>
                </div>



            </div>
            <div class=""col-12 col-md-8 row inner-details-container-two"">

                <div class=""container"">

                    <div class=""details-headings row"" style=""margin-bottom:0px;"">
                        <div class=""details-headings-img-container"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85a96bc61197fe29b6287ba4757471b1e8c3da5012745", async() => {
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
                            <h3>Personal Information</h3>
                        </div>
                    </div>
                    <hr />


                    <div class=""row"">
                        <div class=""col"">
                            <label>
                                ");
#nullable restore
#line 68 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 74 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 80 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 86 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 93 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 99 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 106 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.Role.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 112 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Role.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n\r\n                                ");
#nullable restore
#line 120 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 125 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 132 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 138 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                            </p>
                        </div>
                    </div>

                    <div class=""details-headings row"" style=""margin-bottom:0px;"">
                        <div class=""details-headings-img-container"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85a96bc61197fe29b6287ba4757471b1e8c3da5019716", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
                    </div>
                    <hr />


                    <div class=""row"">
                        <div class=""col"">
                            <label>
                                ");
#nullable restore
#line 158 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.AddressLineOne));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 164 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.AddressLineOne));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 171 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.AddressLineTwo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 177 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.AddressLineTwo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 184 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.ApartmentNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 190 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.ApartmentNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 197 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 203 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 210 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.Province));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 216 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayFor(model => model.Province));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"w-100\"></div>\r\n                        <div class=\"col\">\r\n                            <label>\r\n                                ");
#nullable restore
#line 223 "C:\OASIS\Views\Employees\Details.cshtml"
                           Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </label>\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 229 "C:\OASIS\Views\Employees\Details.cshtml"
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
    <div style=""display:flex; margin-top:50px; margin-bottom:20px;"">
        <div style=""width:12%; margin-right:3.5%; "" class=""button-menu form-group btn btn-primary"">
            <div style=""width:20px; height:22px;"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85a96bc61197fe29b6287ba4757471b1e8c3da5026858", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85a96bc61197fe29b6287ba4757471b1e8c3da5028031", async() => {
                WriteLiteral("\r\n                    Edit\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 244 "C:\OASIS\Views\Employees\Details.cshtml"
                                       WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div style=\"width:17%\" class=\"button-menu form-group btn btn-danger\">\r\n            <div style=\"width:22px; height:25px;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85a96bc61197fe29b6287ba4757471b1e8c3da5030473", async() => {
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
            WriteLiteral("\r\n            </div>\r\n            <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85a96bc61197fe29b6287ba4757471b1e8c3da5031646", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85a96bc61197fe29b6287ba4757471b1e8c3da5031925", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
#nullable restore
#line 257 "C:\OASIS\Views\Employees\Details.cshtml"
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n        <div style=\"width:75%;\">\r\n            <a");
            BeginWriteAttribute("href", " href=\'", 9969, "\'", 9998, 1);
#nullable restore
#line 264 "C:\OASIS\Views\Employees\Details.cshtml"
WriteAttributeValue("", 9976, ViewData["returnURL"], 9976, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
            WriteLiteral(" style=\"float:right; width:19%;\" class=\"btn btn-info\">\r\n                &#8592; Back To List\r\n            </a>\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>");
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
