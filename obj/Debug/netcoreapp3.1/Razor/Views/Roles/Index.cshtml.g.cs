#pragma checksum "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86da2df33fcc016abeabe461f501445e6414b0a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roles_Index), @"mvc.1.0.view", @"/Views/Roles/Index.cshtml")]
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
#line 1 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\_ViewImports.cshtml"
using OASIS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\_ViewImports.cshtml"
using OASIS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86da2df33fcc016abeabe461f501445e6414b0a1", @"/Views/Roles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_Roles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OASIS.Models.Role>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("inner-flex-container-right-items"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString(" width:24%; background-color:#27a9f8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:20%; margin-left:2%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/moreOptions.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ddl-icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("index-drop-down-menu-flex-container"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PagingNavBar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86da2df33fcc016abeabe461f501445e6414b0a18303", async() => {
                WriteLiteral("\r\n    <div class=\"flex-container\">\r\n        <div class=\"inner-flex-container-right\">\r\n\r\n\r\n\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86da2df33fcc016abeabe461f501445e6414b0a18677", async() => {
                    WriteLiteral(@"
                <div style=""width:40%;text-align:right"">
                    <svg style=""width:50%; height:50%"" version=""1.0"" xmlns=""http://www.w3.org/2000/svg""
                         width=""512.000000pt"" height=""512.000000pt"" viewBox=""0 0 512.000000 512.000000""
                         preserveAspectRatio=""xMidYMid meet"">
                        <metadata>
                            Created by potrace 1.16, written by Peter Selinger 2001-2019
                        </metadata>
                        <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)""
                           fill=""#f8f9fa"" stroke=""none"">
                            <path d=""M1660 5109 c-132 -20 -240 -95 -267 -184 -7 -21 -38 -188 -69 -374
                                -32 -185 -61 -341 -66 -348 -5 -7 -33 -19 -61 -29 -112 -36 -240 -107 -303
                                -169 -74 -73 -96 -118 -96 -202 1 -124 82 -219 267 -308 319 -156 832 -237
                                1495 -237 663 0 1176 81 14");
                    WriteLiteral(@"95 237 185 89 266 184 267 308 0 84 -22 129 -96
                                202 -63 62 -191 133 -303 169 -28 10 -56 22 -61 29 -5 7 -28 125 -51 262 -74
                                443 -80 471 -113 519 -39 59 -103 100 -189 121 -112 28 -338 17 -609 -30 -319
                                -54 -337 -54 -655 -5 -288 44 -472 56 -585 39z m240 -219 c63 -6 217 -26 342
                                -45 290 -45 362 -45 633 -1 116 19 254 40 307 46 122 15 262 9 304 -13 28 -14
                                32 -23 42 -84 7 -37 34 -195 60 -350 44 -250 47 -283 33 -287 -52 -15 -247
                                -48 -381 -65 -440 -56 -1011 -53 -1440 9 -92 13 -122 7 -155 -32 -43 -51 -30
                                -139 25 -168 20 -11 168 -32 360 -52 201 -21 913 -17 1120 5 205 23 417 58
                                556 93 94 24 111 25 148 14 99 -30 246 -122 246 -155 0 -40 -146 -124 -300
                                -173 -316 -100 -737 -152 -1240 -152 -503 0 -924 52 -1240 152 -154 49 -300
         ");
                    WriteLiteral(@"                       133 -300 173 0 39 142 122 300 174 102 34 121 44 138 76 7 15 142 761 142 790
                                0 13 57 38 102 45 76 11 72 11 198 0z"" />
                            <path d=""M1514 3170 c-12 -4 -30 -20 -42 -34 -39 -51 -61 -268 -42 -427 22
                                -189 68 -282 171 -349 187 -121 428 -54 521 145 33 72 38 131 24 278 -7 64 -5
                                107 4 159 13 66 12 73 -6 107 -36 68 -139 76 -182 13 -39 -56 -53 -171 -39
                                -323 10 -112 10 -117 -11 -151 -61 -99 -205 -78 -241 34 -14 45 -31 215 -26
                                258 2 19 9 73 16 120 10 76 10 90 -5 118 -27 51 -88 74 -142 52z"" />
                            <path d=""M3504 3161 c-49 -30 -59 -66 -43 -164 18 -106 16 -264 -5 -349 -54
                                -228 -189 -432 -368 -555 -97 -67 -152 -94 -277 -134 -122 -40 -168 -75 -201
                                -151 -19 -44 -22 -64 -17 -128 6 -89 -5 -123 -52 -163 -60 -50 -159 -28 -197
       ");
                    WriteLiteral(@"                         45 -23 43 -31 183 -14 257 41 188 183 330 390 391 111 32 206 86 285 162 151
                                143 222 342 195 546 -14 110 -34 152 -83 175 -33 17 -42 17 -80 5 -33 -10 -46
                                -21 -61 -52 -17 -35 -18 -44 -6 -106 7 -38 11 -100 8 -139 -9 -126 -93 -261
                                -203 -326 -22 -12 -90 -39 -150 -60 -138 -45 -230 -100 -315 -184 -184 -185
                                -258 -451 -194 -700 29 -112 121 -211 229 -247 70 -24 176 -21 247 6 79 29
                                150 96 190 178 30 61 33 75 33 161 l0 95 105 36 c58 20 141 55 185 79 398 213
                                634 657 587 1105 -15 147 -28 184 -71 213 -41 28 -76 29 -117 4z"" />
                            <path d=""M2377 1099 c-107 -25 -208 -114 -248 -217 -16 -42 -22 -80 -22 -143
                                0 -75 3 -94 30 -152 37 -78 98 -141 173 -176 48 -23 68 -26 155 -26 87 0 107
                                3 150 25 61 30 136 103 164 158 50 99 50 2");
                    WriteLiteral(@"46 0 347 -71 142 -244 221 -402 184z
                                m141 -229 c74 -34 103 -137 57 -207 -38 -57 -116 -78 -176 -48 -71 37 -94 154
                                -42 216 27 31 74 58 103 58 8 0 34 -8 58 -19z"" />
                            <path d=""M1590 791 c-380 -82 -561 -195 -562 -352 -1 -70 20 -116 72 -167 176
                                -169 690 -272 1360 -272 746 0 1289 125 1404 323 95 163 -24 321 -309 410
                                -100 31 -303 77 -341 77 -99 0 -148 -128 -75 -194 10 -9 69 -27 132 -41 205
                                -45 375 -108 387 -143 5 -17 -120 -74 -233 -105 -250 -70 -582 -107 -966 -107
                                -346 0 -663 33 -912 94 -129 32 -287 96 -287 116 0 29 241 117 401 146 82 15
                                98 22 128 51 31 31 33 37 28 79 -10 95 -72 118 -227 85z"" />
                        </g>
                    </svg>
                </div>

                <div style=""width:100%;text-align:center"">
                    <p>Add");
                    WriteLiteral(" Role</p>\r\n                </div>\r\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n      \r\n\r\n    </div>\r\n    <div");
                BeginWriteAttribute("class", " class=\"", 5554, "\"", 5595, 2);
                WriteAttributeValue("", 5562, "collapse", 5562, 8, true);
#nullable restore
#line 76 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
WriteAttributeValue(" ", 5570, ViewData["Filtering"], 5571, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" id=""collapseFilter"">
        <div style=""background-color:white!important; border: 1px solid rgba(39,169,248,0.3)"" class=""card card-body bg-light"">
            <div class=""form-row"">
                <div class=""col-md-6"">
                    <div class=""form-group"">
                        <label class=""control-label"">Customer Name:</label>
                        ");
#nullable restore
#line 82 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
                   Write(Html.TextBox("SearchName", null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-md-6\">\r\n                    <div class=\"form-group\">\r\n                        <label class=\"control-label\">Project Name:</label>\r\n                        ");
#nullable restore
#line 88 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
                   Write(Html.TextBox("SearchName", null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-md-6\">\r\n                    <div class=\"form-group\">\r\n                        <label class=\"control-label\">Phone:</label>\r\n                        ");
#nullable restore
#line 94 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
                   Write(Html.TextBox("SearchName", null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-md-6\">\r\n                    <div class=\"form-group\">\r\n                        <label class=\"control-label\">Email Address:</label>\r\n                        ");
#nullable restore
#line 100 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
                   Write(Html.TextBox("SearchEmail", null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </div>
                </div>
            </div>
            <div class=""form-row"">
                <div class=""col-md-6  align-self-end"">
                    <div class=""form-group"">
                        <input style=""width:20%;"" type=""submit"" name=""actionButton"" value=""Filter"" class=""btn btn-primary"" />
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86da2df33fcc016abeabe461f501445e6414b0a118695", async() => {
                    WriteLiteral("Clear");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 119 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 123 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.LabourCostPerHr));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 127 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.LabourPricePerHr));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n\r\n\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 135 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n\r\n\r\n                    <td>\r\n\r\n                        ");
#nullable restore
#line 142 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 147 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.LabourPricePerHr));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 151 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.LabourCostPerHr));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td style=\"padding-top:0px; position:relative\" class=\"table-row-img\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "86da2df33fcc016abeabe461f501445e6414b0a122915", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 154 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
AddHtmlAttributeValue("", 8597, item.ID, 8597, 8, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 8667, "divVisibility(", 8667, 14, true);
#nullable restore
#line 154 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
AddHtmlAttributeValue("", 8681, item.ID, 8681, 8, false);

#line default
#line hidden
#nullable disable
                AddHtmlAttributeValue("", 8689, ")", 8689, 1, true);
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div");
                BeginWriteAttribute("id", " id=\"", 8745, "\"", 8762, 2);
#nullable restore
#line 155 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
WriteAttributeValue("", 8750, item.ID, 8750, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 8758, "-ddl", 8758, 4, true);
                EndWriteAttribute();
                WriteLiteral(" class=\"index-drop-down-menu\" style=\"height:45px;\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86da2df33fcc016abeabe461f501445e6414b0a125818", async() => {
                    WriteLiteral(@"
                                <div class=""index-drop-down-menu-flex-container-img"">

                                    <svg version=""1.0"" xmlns=""http://www.w3.org/2000/svg""
                                         width=""512.000000pt"" height=""512.000000pt"" viewBox=""0 0 512.000000 512.000000""
                                         preserveAspectRatio=""xMidYMid meet"">
                                        <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)""
                                           fill=""#000000"" stroke=""none"">
                                            <path d=""M3625 5106 c-63 -29 -98 -90 -110 -192 l-7 -61 -99 -40 -99 -40 -59
                        43 c-82 61 -166 74 -236 36 -11 -6 -68 -59 -126 -119 -103 -104 -129 -145
                        -129 -203 0 -38 24 -91 64 -145 l44 -59 -28 -60 c-15 -34 -32 -77 -39 -97 -12
                        -36 -13 -37 -87 -48 -87 -13 -122 -28 -157 -71 -38 -44 -47 -89 -47 -230 0
                        -144 9 -187 51 ");
                    WriteLiteral(@"-234 35 -41 83 -61 166 -71 60 -7 62 -8 74 -43 6 -21 24 -64
                        39 -98 l27 -61 -43 -58 c-67 -90 -78 -159 -37 -240 23 -44 171 -193 223 -223
                        34 -21 58 -27 102 -27 53 0 63 4 131 51 68 48 75 51 98 38 13 -7 56 -25 96
                        -40 l71 -26 7 -62 c13 -116 62 -184 148 -207 64 -17 314 -8 353 14 66 35 94
                        87 109 204 6 49 9 53 43 64 21 6 64 24 98 39 l61 27 58 -43 c54 -40 107 -64
                        145 -64 58 0 99 26 203 129 60 58 114 117 121 131 38 74 26 146 -39 233 l-42
                        57 40 99 40 99 61 7 c112 13 187 65 201 138 4 18 5 105 3 193 -3 158 -3 161
                        -31 197 -37 48 -70 65 -161 78 l-74 11 -18 47 c-9 25 -27 68 -40 95 -13 27
                        -21 54 -17 60 4 6 23 34 44 61 59 79 70 154 33 225 -22 45 -227 238 -259 245
                        -17 4 -35 8 -41 10 -33 10 -111 -18 -167 -60 l-60 -44 -36 15 c-50 22 -123 51
                        -142 57 -12 4 -20 27 -28 82 -13 92 -29 125 -78");
                    WriteLiteral(@" 162 -36 28 -37 28 -212 30
                        -132 2 -184 -1 -206 -11z m280 -273 c8 -72 30 -126 63 -156 11 -10 60 -33 109
                        -51 48 -18 113 -46 143 -62 41 -21 69 -28 110 -28 58 0 85 11 158 66 l43 32
                        51 -52 52 -51 -32 -43 c-55 -73 -66 -100 -66 -158 0 -41 7 -69 28 -110 16 -30
                        44 -95 62 -143 18 -49 41 -98 51 -109 27 -31 90 -56 161 -64 l62 -7 0 -77 0
                        -78 -62 -7 c-77 -8 -141 -37 -168 -76 -12 -16 -31 -59 -44 -96 -13 -38 -38
                        -97 -56 -133 -57 -110 -47 -181 42 -293 l22 -27 -49 -50 c-27 -28 -53 -50 -58
                        -50 -4 0 -31 18 -60 39 -92 69 -152 73 -262 18 -33 -16 -90 -40 -128 -53 -122
                        -42 -159 -86 -173 -211 l-7 -63 -77 0 -78 0 -7 63 c-12 112 -64 183 -150 203
                        -16 4 -75 27 -130 52 -145 66 -192 63 -303 -20 l-43 -32 -51 52 -52 51 32 43
                        c83 111 86 158 20 303 -25 55 -48 114 -52 130 -20 86 -91 138 -203 150 l-6");
                    WriteLiteral(@"3 7
                        0 78 0 77 63 7 c76 9 140 38 167 77 12 16 31 59 44 96 13 38 37 95 53 128 55
                        110 51 170 -18 262 -21 29 -39 56 -39 60 0 5 22 31 50 58 l50 49 27 -22 c112
                        -89 183 -99 293 -42 36 18 95 43 133 56 37 13 80 32 96 44 39 27 68 91 76 168
                        l7 62 78 0 78 0 7 -67z"" />
                                            <path d=""M3699 4272 c-350 -92 -465 -527 -208 -784 181 -181 477 -182 658 -1
                        183 184 185 480 2 661 -69 70 -139 108 -228 127 -88 19 -142 18 -224 -3z m204
                        -216 c94 -34 156 -116 164 -220 9 -104 -43 -192 -139 -240 -164 -82 -357 39
                        -358 224 0 171 172 293 333 236z"" />
                                            <path d=""M1195 3390 c-68 -17 -352 -143 -378 -168 -72 -68 -84 -154 -43 -306
                        l24 -89 -37 -30 c-42 -36 -191 -189 -191 -197 0 -3 -52 7 -117 23 -107 27
                        -121 28 -171 17 -44 -10 -64 -21 -101 -59 -39");
                    WriteLiteral(@" -40 -56 -71 -114 -214 -75 -186
                        -84 -245 -48 -322 23 -50 45 -69 152 -133 l85 -51 0 -166 -1 -165 -85 -51
                        c-101 -60 -126 -82 -151 -131 -36 -71 -27 -138 42 -304 74 -179 90 -213 121
                        -240 65 -60 145 -68 294 -30 l90 23 54 -62 c29 -34 81 -86 115 -115 l62 -54
                        -23 -90 c-39 -153 -28 -243 38 -302 30 -28 57 -41 231 -113 167 -69 234 -78
                        305 -42 49 25 71 50 131 151 l51 85 165 1 165 1 52 -86 c64 -107 83 -129 133
                        -152 78 -36 137 -27 323 48 141 58 174 75 213 114 38 37 49 57 59 101 11 50
                        10 64 -17 171 -16 65 -26 117 -23 117 8 0 161 149 197 191 l30 37 89 -24 c152
                        -41 238 -29 306 43 30 31 162 339 173 402 10 61 -16 138 -62 182 -21 20 -74
                        57 -117 83 l-80 45 0 166 -1 166 79 46 c144 85 180 133 180 238 -1 51 -11 85
                        -72 230 -84 199 -118 242 -211 265 -49 12 -62 10 -166 -15 l-112 -28 -117 11");
                    WriteLiteral(@"8
                        -118 118 27 111 c25 100 26 115 15 165 -21 94 -64 129 -263 211 -194 80 -219
                        86 -285 70 -69 -16 -114 -58 -176 -163 l-54 -92 -166 1 -167 0 -45 80 c-62
                        106 -106 151 -168 169 -54 16 -75 17 -121 5z m106 -341 c45 -75 66 -100 104
                        -124 l48 -30 226 -1 c124 -1 242 3 261 9 59 16 98 54 156 152 30 52 56 95 58
                        95 6 0 237 -97 242 -102 2 -3 -7 -52 -21 -109 -42 -165 -23 -227 103 -332 39
                        -32 97 -90 129 -129 105 -126 163 -145 328 -103 59 14 109 24 113 21 4 -5 102
                        -236 102 -242 0 -2 -43 -28 -95 -58 -98 -58 -135 -97 -153 -156 -5 -20 -9
                        -134 -8 -261 l1 -226 30 -48 c24 -38 49 -59 119 -101 49 -29 93 -57 97 -61 7
                        -7 -79 -234 -94 -250 -3 -2 -47 7 -98 21 -185 51 -198 46 -410 -166 -161 -161
                        -168 -170 -180 -223 -11 -51 -10 -65 15 -166 16 -61 26 -112 24 -114 -4 -4
                        -10");
                    WriteLiteral(@"4 -47 -200 -85 l-46 -19 -55 92 c-99 166 -98 165 -414 163 l-241 -1 -44
                        -30 c-30 -22 -60 -59 -100 -125 -32 -53 -63 -94 -70 -92 -14 3 -231 92 -236
                        97 -2 1 8 47 22 101 49 187 47 193 -164 404 -211 211 -217 213 -404 164 -54
                        -14 -100 -24 -101 -22 -5 5 -94 222 -97 236 -2 7 39 38 92 70 66 40 103 70
                        125 100 l30 44 1 241 c2 316 3 315 -163 414 l-92 55 19 46 c39 98 81 196 85
                        200 2 3 54 -8 115 -23 102 -26 114 -27 168 -15 52 11 63 19 132 92 41 44 98
                        101 125 127 168 155 179 188 129 370 -14 51 -24 95 -22 97 10 9 234 102 243
                        100 5 -1 35 -45 66 -97z"" />
                                            <path d=""M1530 2464 c-233 -50 -431 -205 -536 -419 -64 -131 -79 -196 -78
                        -350 0 -104 4 -146 22 -208 77 -270 278 -471 548 -549 103 -30 304 -32 404 -5
                        338 91 572 379 588 723 15 342 -174 642 -485 769 -131 53 -324 69 -");
                    WriteLiteral(@"463 39z
                        m351 -256 c216 -80 359 -284 359 -513 0 -293 -250 -544 -542 -545 -294 -1
                        -549 254 -548 548 1 238 174 460 411 527 81 23 235 14 320 -17z"" />
                                        </g>
                                    </svg>
                                </div>
                                <p>Edit</p>
                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 156 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
                                                   WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                           \r\n                            \r\n                        </div>\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 245 "C:\Users\rufar\OneDrive - NC\SEMESTER4\PROG1440\QuickAdd\Views\Roles\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "86da2df33fcc016abeabe461f501445e6414b0a136451", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OASIS.Models.Role>> Html { get; private set; }
    }
}
#pragma warning restore 1591
