#pragma checksum "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\Toolttipp\Views\ApprovalStatus\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18bed393c07b82276ff3a9b337543395c7b7bd78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ApprovalStatus_Create), @"mvc.1.0.view", @"/Views/ApprovalStatus/Create.cshtml")]
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
#line 1 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\Toolttipp\Views\_ViewImports.cshtml"
using OASIS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\Toolttipp\Views\_ViewImports.cshtml"
using OASIS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18bed393c07b82276ff3a9b337543395c7b7bd78", @"/Views/ApprovalStatus/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_ApprovalStatus_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OASIS.Models.ApprovalStatus>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right; width:10%; color:white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placement", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Return to Approval Status Page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\Toolttipp\Views\ApprovalStatus\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18bed393c07b82276ff3a9b337543395c7b7bd787215", async() => {
                WriteLiteral(@"

    <div class=""row"">
        <div class=""form-row col-10"">
            <div style=""width:35px; height:37px; align-self:center;"">
                <svg style=""width:100%;height:100%;"" id=""Capa_1"" enable-background=""new 0 0 512 512"" height=""512"" viewBox=""0 0 512 512"" width=""512"" xmlns=""http://www.w3.org/2000/svg""><g fill=""#7460ee""><path d=""m346.555 65.585-31.819 31.819 53.033 53.033 74.245-74.246-31.819-31.819-42.426 42.426zm74.246 10.606-53.032 53.033-31.82-31.82 10.606-10.606 21.214 21.213 42.426-42.426z""></path><path d=""m464.528 89.904h15v15h-15z""></path><path d=""m277.221 0v194.808h68.048l33.106 33.107 33.105-33.107h68.048v-74.904h-15v59.904h-59.26l-26.893 26.893-26.894-26.893h-59.26v-164.808h172.307v59.904h15v-74.904z""></path><path d=""m389.72 294.5c0-20.678-16.822-37.5-37.5-37.5h-97.499v-34.899c0-20.739-3.378-35.177-10.629-45.438-8.637-12.221-22.332-18.161-41.871-18.161h-22.499v89.636l-17.444 46.362h-129.806v142.5h15v-127.5h59.999v172.499h-59.999v-30h-15v45h89.999v-15h56.623l45 30.001h120.853c20.553 ");
                WriteLiteral(@"0 37.273-16.822 37.273-37.5 0-10.724-4.532-20.403-11.772-27.244 11.485-6.417 19.272-18.691 19.272-32.756 0-12.254-5.909-23.153-15.026-30 9.117-6.847 15.026-17.746 15.026-30s-5.909-23.152-15.026-30c9.117-6.847 15.026-17.746 15.026-30zm-267.249 15h14.999v157.499h-14.999zm61.164 157.499h-31.165v-157.499h20.191l22.061-58.635v-77.364h7.499c27.336 0 37.5 13.172 37.5 48.6v72.4h15v-22.501h22.521c-4.719 6.272-7.521 14.065-7.521 22.5 0 12.254 5.909 23.153 15.026 30-9.117 6.847-15.026 17.746-15.026 30s5.909 23.153 15.026 30c-9.117 6.847-15.026 17.746-15.026 30 0 14.065 7.787 26.339 19.272 32.756-7.24 6.841-11.772 16.521-11.772 27.244 0 8.436 2.801 16.228 7.521 22.5h-56.106zm161.311 30.001h-30.226c-12.406 0-22.5-10.093-22.5-22.5s10.094-22.5 22.5-22.5h29.999c12.406 0 22.5 10.093 22.5 22.5s-9.991 22.5-22.273 22.5zm29.774-82.5c0 12.407-10.094 22.5-22.5 22.5h-44.999c-12.406 0-22.5-10.093-22.5-22.5s10.094-22.5 22.5-22.5h44.999c12.406 0 22.5 10.093 22.5 22.5zm0-60c0 12.407-10.094 22.5-22.5 22.5h-44.999c-12.406 0-22.5-10.093-22");
                WriteLiteral(@".5-22.5 0-12.406 10.094-22.5 22.5-22.5h44.999c12.406 0 22.5 10.094 22.5 22.5zm-22.5-37.5h-44.999c-12.406 0-22.5-10.093-22.5-22.5s10.094-22.5 22.5-22.5h44.999c12.406 0 22.5 10.094 22.5 22.5 0 12.407-10.094 22.5-22.5 22.5z""></path><path d=""m77.471 324.5h15v15h-15z""></path><path d=""m77.471 354.5h15v15h-15z""></path></g></svg>
            </div>
            <h2 style=""margin-left: 14px; margin-top:5px; color:#7460ee"">Add Approval Status</h2>

        </div>
        <div class=""col-md-6"">

            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18bed393c07b82276ff3a9b337543395c7b7bd7810136", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 20 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\Toolttipp\Views\ApprovalStatus\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <div class=\"form-group\" style=\"margin-top:3%\">\r\n                <label class=\"control-label\">Approval Status Message</label>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "18bed393c07b82276ff3a9b337543395c7b7bd7811981", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 23 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\Toolttipp\Views\ApprovalStatus\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18bed393c07b82276ff3a9b337543395c7b7bd7813581", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 24 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\Toolttipp\Views\ApprovalStatus\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
    <div style=""display:flex; margin-top:50px; margin-bottom:20px;"">
        <button  type=""submit"" style=""width: 6%;margin-right:3.5%;"" class=""button-menu form-group btn btn-success"" data-toggle=""tooltip"" data-placement=""top"" title=""Save Approval"">
            <div style=""width:20px; height:22px;"">
                <svg version=""1.0"" xmlns=""http://www.w3.org/2000/svg"" width=""512.000000pt"" height=""512.000000pt"" viewBox=""0 0 512.000000 512.000000"" preserveAspectRatio=""xMidYMid meet"">

                    <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)"" fill=""white"" stroke=""none"">
                        <path d=""M66 5101 c-15 -10 -37 -32 -47 -47 -18 -28 -19 -96 -19 -2494 0
                                -2398 1 -2466 19 -2494 10 -15 32 -37 47 -47 28 -18 96 -19 2494 -19 2398 0
                                2466 1 2494 19 15 10 37 32 47 47 18 28 19 88 19 2095 l0 2066 -29 39 c-34 46
                                -805 814 -");
                WriteLiteral(@"841 838 -21 14 -64 16 -332 16 l-307 0 -3 -742 -3 -743 -22 -35
                                c-12 -19 -37 -44 -55 -55 -33 -20 -51 -20 -1268 -20 l-1235 0 -35 22 c-19 12
                                -44 37 -55 55 -19 32 -20 53 -23 776 l-3 742 -407 0 c-382 0 -409 -1 -436 -19z
                                m3844 -3751 l0 -1050 -1350 0 -1350 0 0 1050 0 1050 1350 0 1350 0 0 -1050z""></path>
                        <path d=""M1576 2081 c-46 -31 -66 -69 -66 -131 0 -62 20 -100 66 -131 28 -18
                                65 -19 984 -19 919 0 956 1 984 19 46 31 66 69 66 131 0 62 -20 100 -66 131
                                -28 18 -65 19 -984 19 -919 0 -956 -1 -984 -19z""></path>
                        <path d=""M1576 1481 c-46 -31 -66 -69 -66 -131 0 -62 20 -100 66 -131 28 -18
                                65 -19 984 -19 919 0 956 1 984 19 46 31 66 69 66 131 0 62 -20 100 -66 131
                                -28 18 -65 19 -984 19 -919 0 -956 -1 -984 -19z""></path>
                        <path d=""M1");
                WriteLiteral(@"576 881 c-46 -31 -66 -69 -66 -131 0 -62 20 -100 66 -131 28 -18
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

                    <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)"" fill=""white"" stroke=""none"">
   ");
                WriteLiteral(@"                     <path d=""M2265 5109 c-108 -13 -301 -53 -409 -84 -338 -98 -691 -287 -957
                                -513 l-106 -90 -214 215 c-248 250 -279 273 -358 273 -89 -1 -154 -38 -202
                                -115 -18 -29 -19 -65 -19 -838 0 -706 2 -812 15 -845 20 -47 50 -78 100 -105
                                40 -22 44 -22 805 -25 421 -2 788 0 817 3 62 7 107 36 145 90 42 61 54 121 38
                                181 -12 44 -36 72 -262 300 l-249 251 63 55 c180 158 436 287 695 353 290 73
                                645 55 938 -47 616 -214 1057 -752 1140 -1391 96 -739 -309 -1461 -990 -1764
                                -256 -114 -484 -160 -755 -150 -181 7 -299 27 -465 82 -298 97 -540 257 -749
                                495 -101 115 -128 131 -193 116 -40 -9 -519 -496 -526 -535 -11 -52 11 -94
                                100 -194 326 -364 788 -638 1275 -757 225 -55 318 -65 618 -65 300 0 385 9
                                610 65 352 88 705 261 995 488 116 91 34");
                WriteLiteral(@"6 328 437 452 286 386 459 820 508
                                1272 22 205 10 538 -25 728 -74 400 -234 763 -483 1100 -91 124 -321 361 -437
                                452 -344 270 -755 453 -1190 530 -128 22 -575 33 -710 17z""></path>
                    </g>
                </svg>
            </div>

        </button>
        <div style=""width:75%;"">
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18bed393c07b82276ff3a9b337543395c7b7bd7819938", async() => {
                    WriteLiteral("\r\n                ←\r\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OASIS.Models.ApprovalStatus> Html { get; private set; }
    }
}
#pragma warning restore 1591