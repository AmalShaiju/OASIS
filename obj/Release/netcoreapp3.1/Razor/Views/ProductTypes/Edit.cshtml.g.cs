#pragma checksum "C:\OASIS\Views\ProductTypes\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "580b55d3a0f72fc9c63b229267efc97d5c1aed8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductTypes_Edit), @"mvc.1.0.view", @"/Views/ProductTypes/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"580b55d3a0f72fc9c63b229267efc97d5c1aed8b", @"/Views/ProductTypes/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductTypes_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OASIS.Models.ProductType>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-sm-3 col-form-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("tabindex", new global::Microsoft.AspNetCore.Html.HtmlString("1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Example: In Progress"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "580b55d3a0f72fc9c63b229267efc97d5c1aed8b5941", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "580b55d3a0f72fc9c63b229267efc97d5c1aed8b6207", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 5 "C:\OASIS\Views\ProductTypes\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RowVersion);

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
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"returnURL\"");
                BeginWriteAttribute("value", " value=\"", 195, "\"", 225, 1);
#nullable restore
#line 6 "C:\OASIS\Views\ProductTypes\Edit.cshtml"
WriteAttributeValue("", 203, ViewData["returnURL"], 203, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />

        <div class=""card col-8 p-0 mb-5"" style="" border-radius:25px"">
            <div style="" border-top-left-radius: 25px; border-top-right-radius: 25px;"" class=""row card-header m-0"">
                <div style=""text-align:center"" class=""col-1"">
                    <span class=""material-icons"">
                        category
                    </span>
                </div>
                <div class=""col-10"">
                    <h5>Status Message</h5>
                </div>
                <div class=""col-1"">
                    <button type=""button"" style=""padding:0;width:50%;"" class=""btn btn-outline-light"" data-toggle=""collapse"" data-target=""#collapse-personal"" aria-expanded=""false"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" height=""24"" viewBox=""0 0 24 24"" width=""24""><path d=""M0 0h24v24H0z"" fill=""none"" /><path d=""M16.59 8.59L12 13.17 7.41 8.59 6 10l6 6 6-6z"" /></svg>
                    </button>
                </div>
            </div>
            <div c");
                WriteLiteral("lass=\"card-body\" id=\"collapse-personal\" style=\"background: rgba(184, 175, 247, 0.2); border-bottom-left-radius: 25px; border-bottom-right-radius: 25px;\">\r\n                <div class=\"form-group row ml-3\">\r\n\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "580b55d3a0f72fc9c63b229267efc97d5c1aed8b9608", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 27 "C:\OASIS\Views\ProductTypes\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <div class=\"col-sm-8\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "580b55d3a0f72fc9c63b229267efc97d5c1aed8b11216", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 29 "C:\OASIS\Views\ProductTypes\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "580b55d3a0f72fc9c63b229267efc97d5c1aed8b12945", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 30 "C:\OASIS\Views\ProductTypes\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>

        <div style=""display:flex; margin-top:50px; margin-bottom:20px;"">
            <button type=""submit"" style=""width: 6%;margin-right:3.5%;"" class=""button-menu form-group btn btn-success"" data-toggle=""tooltip"" data-placement=""top"" title=""Save Product Type"">
                <div style=""width:20px; height:22px;"">
                    <svg version=""1.0"" xmlns=""http://www.w3.org/2000/svg"" width=""512.000000pt"" height=""512.000000pt"" viewBox=""0 0 512.000000 512.000000"" preserveAspectRatio=""xMidYMid meet"">

                        <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)"" fill=""white"" stroke=""none"">
                            <path d=""M66 5101 c-15 -10 -37 -32 -47 -47 -18 -28 -19 -96 -19 -2494 0
                                -2398 1 -2466 19 -2494 10 -15 32 -37 47 -47 28 -18 96 -19 2494 -19 2398 0
                                2466 1 2494 19 15 10 37 32 47 47 18 28 19 88 19 2095 l0 ");
                WriteLiteral(@"2066 -29 39 c-34 46
                                -805 814 -841 838 -21 14 -64 16 -332 16 l-307 0 -3 -742 -3 -743 -22 -35
                                c-12 -19 -37 -44 -55 -55 -33 -20 -51 -20 -1268 -20 l-1235 0 -35 22 c-19 12
                                -44 37 -55 55 -19 32 -20 53 -23 776 l-3 742 -407 0 c-382 0 -409 -1 -436 -19z
                                m3844 -3751 l0 -1050 -1350 0 -1350 0 0 1050 0 1050 1350 0 1350 0 0 -1050z""></path>
                            <path d=""M1576 2081 c-46 -31 -66 -69 -66 -131 0 -62 20 -100 66 -131 28 -18
                                65 -19 984 -19 919 0 956 1 984 19 46 31 66 69 66 131 0 62 -20 100 -66 131
                                -28 18 -65 19 -984 19 -919 0 -956 -1 -984 -19z""></path>
                            <path d=""M1576 1481 c-46 -31 -66 -69 -66 -131 0 -62 20 -100 66 -131 28 -18
                                65 -19 984 -19 919 0 956 1 984 19 46 31 66 69 66 131 0 62 -20 100 -66 131
                                -28 18 -65 19 -984 19");
                WriteLiteral(@" -919 0 -956 -1 -984 -19z""></path>
                            <path d=""M1576 881 c-46 -31 -66 -69 -66 -131 0 -62 20 -100 66 -131 28 -18
                                65 -19 984 -19 919 0 956 1 984 19 46 31 66 69 66 131 0 62 -20 100 -66 131
                                -28 18 -65 19 -984 19 -919 0 -956 -1 -984 -19z""></path>
                            <path d=""M1210 4470 l0 -650 1050 0 1050 0 0 650 0 650 -1050 0 -1050 0 0
                                -650z""></path>
                        </g>
                    </svg>

                </div>

            </button>

            <button type=""reset"" style=""width: 6%;"" class=""button-menu form-group btn btn-dark"" data-toggle=""tooltip"" data-placement=""top"" title=""Reset Changes"">
                <div style=""width:20px; height:22px;"">
                    <svg version=""1.0"" xmlns=""http://www.w3.org/2000/svg"" width=""512.000000pt"" height=""512.000000pt"" viewBox=""0 0 512.000000 512.000000"" preserveAspectRatio=""xMidYMid meet"">

                 ");
                WriteLiteral(@"       <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)"" fill=""white"" stroke=""none"">
                            <path d=""M2265 5109 c-108 -13 -301 -53 -409 -84 -338 -98 -691 -287 -957
                                -513 l-106 -90 -214 215 c-248 250 -279 273 -358 273 -89 -1 -154 -38 -202
                                -115 -18 -29 -19 -65 -19 -838 0 -706 2 -812 15 -845 20 -47 50 -78 100 -105
                                40 -22 44 -22 805 -25 421 -2 788 0 817 3 62 7 107 36 145 90 42 61 54 121 38
                                181 -12 44 -36 72 -262 300 l-249 251 63 55 c180 158 436 287 695 353 290 73
                                645 55 938 -47 616 -214 1057 -752 1140 -1391 96 -739 -309 -1461 -990 -1764
                                -256 -114 -484 -160 -755 -150 -181 7 -299 27 -465 82 -298 97 -540 257 -749
                                495 -101 115 -128 131 -193 116 -40 -9 -519 -496 -526 -535 -11 -52 11 -94
                                100 -194 326 -364 788 -638 127");
                WriteLiteral(@"5 -757 225 -55 318 -65 618 -65 300 0 385 9
                                610 65 352 88 705 261 995 488 116 91 346 328 437 452 286 386 459 820 508
                                1272 22 205 10 538 -25 728 -74 400 -234 763 -483 1100 -91 124 -321 361 -437
                                452 -344 270 -755 453 -1190 530 -128 22 -575 33 -710 17z""></path>
                        </g>
                    </svg>
                </div>

            </button>
            <div style=""width:75%;"">
                <a");
                BeginWriteAttribute("href", " href=\'", 6405, "\'", 6434, 1);
#nullable restore
#line 90 "C:\OASIS\Views\ProductTypes\Edit.cshtml"
WriteAttributeValue("", 6412, ViewData["returnURL"], 6412, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" ");
                WriteLiteral(" style=\"float:right; width:10%;\" class=\"btn btn-info\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Return to Product Types Page\">\r\n                    ←\r\n                </a>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OASIS.Models.ProductType> Html { get; private set; }
    }
}
#pragma warning restore 1591
