#pragma checksum "C:\OASIS\Views\ApprovalStatus\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a19acc35c48f3c96d7decb3676d869210ab0aed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ApprovalStatus_Index), @"mvc.1.0.view", @"/Views/ApprovalStatus/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a19acc35c48f3c96d7decb3676d869210ab0aed", @"/Views/ApprovalStatus/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_ApprovalStatus_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OASIS.Models.ApprovalStatus>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/moreOptions.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ddl-icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("index-drop-down-menu-flex-container"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 12 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 18 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 21 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td style=\"padding-top:0px; position:relative\" class=\"table-row-img\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8a19acc35c48f3c96d7decb3676d869210ab0aed6390", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 24 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
AddHtmlAttributeValue("", 556, item.ID, 556, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 626, "divVisibility(", 626, 14, true);
#nullable restore
#line 24 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
AddHtmlAttributeValue("", 640, item.ID, 640, 8, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 648, ")", 648, 1, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 696, "\"", 713, 2);
#nullable restore
#line 25 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
WriteAttributeValue("", 701, item.ID, 701, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 709, "-ddl", 709, 4, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"index-drop-down-menu\" style=\"height:95px\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a19acc35c48f3c96d7decb3676d869210ab0aed9037", async() => {
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
                        -144 9 -187 51 -234 35 -41 83 -61 166 -71 60 -7 62 -8 74 -43 6 -21 24 -");
                WriteLiteral(@"64
                        39 -98 l27 -61 -43 -58 c-67 -90 -78 -159 -37 -240 23 -44 171 -193 223 -223
                        34 -21 58 -27 102 -27 53 0 63 4 131 51 68 48 75 51 98 38 13 -7 56 -25 96
                        -40 l71 -26 7 -62 c13 -116 62 -184 148 -207 64 -17 314 -8 353 14 66 35 94
                        87 109 204 6 49 9 53 43 64 21 6 64 24 98 39 l61 27 58 -43 c54 -40 107 -64
                        145 -64 58 0 99 26 203 129 60 58 114 117 121 131 38 74 26 146 -39 233 l-42
                        57 40 99 40 99 61 7 c112 13 187 65 201 138 4 18 5 105 3 193 -3 158 -3 161
                        -31 197 -37 48 -70 65 -161 78 l-74 11 -18 47 c-9 25 -27 68 -40 95 -13 27
                        -21 54 -17 60 4 6 23 34 44 61 59 79 70 154 33 225 -22 45 -227 238 -259 245
                        -17 4 -35 8 -41 10 -33 10 -111 -18 -167 -60 l-60 -44 -36 15 c-50 22 -123 51
                        -142 57 -12 4 -20 27 -28 82 -13 92 -29 125 -78 162 -36 28 -37 28 -212 30
                        -132");
                WriteLiteral(@" 2 -184 -1 -206 -11z m280 -273 c8 -72 30 -126 63 -156 11 -10 60 -33 109
                        -51 48 -18 113 -46 143 -62 41 -21 69 -28 110 -28 58 0 85 11 158 66 l43 32
                        51 -52 52 -51 -32 -43 c-55 -73 -66 -100 -66 -158 0 -41 7 -69 28 -110 16 -30
                        44 -95 62 -143 18 -49 41 -98 51 -109 27 -31 90 -56 161 -64 l62 -7 0 -77 0
                        -78 -62 -7 c-77 -8 -141 -37 -168 -76 -12 -16 -31 -59 -44 -96 -13 -38 -38
                        -97 -56 -133 -57 -110 -47 -181 42 -293 l22 -27 -49 -50 c-27 -28 -53 -50 -58
                        -50 -4 0 -31 18 -60 39 -92 69 -152 73 -262 18 -33 -16 -90 -40 -128 -53 -122
                        -42 -159 -86 -173 -211 l-7 -63 -77 0 -78 0 -7 63 c-12 112 -64 183 -150 203
                        -16 4 -75 27 -130 52 -145 66 -192 63 -303 -20 l-43 -32 -51 52 -52 51 32 43
                        c83 111 86 158 20 303 -25 55 -48 114 -52 130 -20 86 -91 138 -203 150 l-63 7
                        0 78 0 77 63 7 c76 9 140 38");
                WriteLiteral(@" 167 77 12 16 31 59 44 96 13 38 37 95 53 128 55
                        110 51 170 -18 262 -21 29 -39 56 -39 60 0 5 22 31 50 58 l50 49 27 -22 c112
                        -89 183 -99 293 -42 36 18 95 43 133 56 37 13 80 32 96 44 39 27 68 91 76 168
                        l7 62 78 0 78 0 7 -67z"" />
                                    <path d=""M3699 4272 c-350 -92 -465 -527 -208 -784 181 -181 477 -182 658 -1
                        183 184 185 480 2 661 -69 70 -139 108 -228 127 -88 19 -142 18 -224 -3z m204
                        -216 c94 -34 156 -116 164 -220 9 -104 -43 -192 -139 -240 -164 -82 -357 39
                        -358 224 0 171 172 293 333 236z"" />
                                    <path d=""M1195 3390 c-68 -17 -352 -143 -378 -168 -72 -68 -84 -154 -43 -306
                        l24 -89 -37 -30 c-42 -36 -191 -189 -191 -197 0 -3 -52 7 -117 23 -107 27
                        -121 28 -171 17 -44 -10 -64 -21 -101 -59 -39 -40 -56 -71 -114 -214 -75 -186
                        -84 -245 -48 -3");
                WriteLiteral(@"22 23 -50 45 -69 152 -133 l85 -51 0 -166 -1 -165 -85 -51
                        c-101 -60 -126 -82 -151 -131 -36 -71 -27 -138 42 -304 74 -179 90 -213 121
                        -240 65 -60 145 -68 294 -30 l90 23 54 -62 c29 -34 81 -86 115 -115 l62 -54
                        -23 -90 c-39 -153 -28 -243 38 -302 30 -28 57 -41 231 -113 167 -69 234 -78
                        305 -42 49 25 71 50 131 151 l51 85 165 1 165 1 52 -86 c64 -107 83 -129 133
                        -152 78 -36 137 -27 323 48 141 58 174 75 213 114 38 37 49 57 59 101 11 50
                        10 64 -17 171 -16 65 -26 117 -23 117 8 0 161 149 197 191 l30 37 89 -24 c152
                        -41 238 -29 306 43 30 31 162 339 173 402 10 61 -16 138 -62 182 -21 20 -74
                        57 -117 83 l-80 45 0 166 -1 166 79 46 c144 85 180 133 180 238 -1 51 -11 85
                        -72 230 -84 199 -118 242 -211 265 -49 12 -62 10 -166 -15 l-112 -28 -117 118
                        -118 118 27 111 c25 100 26 115 15 165 -21 94 ");
                WriteLiteral(@"-64 129 -263 211 -194 80 -219
                        86 -285 70 -69 -16 -114 -58 -176 -163 l-54 -92 -166 1 -167 0 -45 80 c-62
                        106 -106 151 -168 169 -54 16 -75 17 -121 5z m106 -341 c45 -75 66 -100 104
                        -124 l48 -30 226 -1 c124 -1 242 3 261 9 59 16 98 54 156 152 30 52 56 95 58
                        95 6 0 237 -97 242 -102 2 -3 -7 -52 -21 -109 -42 -165 -23 -227 103 -332 39
                        -32 97 -90 129 -129 105 -126 163 -145 328 -103 59 14 109 24 113 21 4 -5 102
                        -236 102 -242 0 -2 -43 -28 -95 -58 -98 -58 -135 -97 -153 -156 -5 -20 -9
                        -134 -8 -261 l1 -226 30 -48 c24 -38 49 -59 119 -101 49 -29 93 -57 97 -61 7
                        -7 -79 -234 -94 -250 -3 -2 -47 7 -98 21 -185 51 -198 46 -410 -166 -161 -161
                        -168 -170 -180 -223 -11 -51 -10 -65 15 -166 16 -61 26 -112 24 -114 -4 -4
                        -104 -47 -200 -85 l-46 -19 -55 92 c-99 166 -98 165 -414 163 l-241 -1 -44
 ");
                WriteLiteral(@"                       -30 c-30 -22 -60 -59 -100 -125 -32 -53 -63 -94 -70 -92 -14 3 -231 92 -236
                        97 -2 1 8 47 22 101 49 187 47 193 -164 404 -211 211 -217 213 -404 164 -54
                        -14 -100 -24 -101 -22 -5 5 -94 222 -97 236 -2 7 39 38 92 70 66 40 103 70
                        125 100 l30 44 1 241 c2 316 3 315 -163 414 l-92 55 19 46 c39 98 81 196 85
                        200 2 3 54 -8 115 -23 102 -26 114 -27 168 -15 52 11 63 19 132 92 41 44 98
                        101 125 127 168 155 179 188 129 370 -14 51 -24 95 -22 97 10 9 234 102 243
                        100 5 -1 35 -45 66 -97z"" />
                                    <path d=""M1530 2464 c-233 -50 -431 -205 -536 -419 -64 -131 -79 -196 -78
                        -350 0 -104 4 -146 22 -208 77 -270 278 -471 548 -549 103 -30 304 -32 404 -5
                        338 91 572 379 588 723 15 342 -174 642 -485 769 -131 53 -324 69 -463 39z
                        m351 -256 c216 -80 359 -284 359 -513 0 -293 -25");
                WriteLiteral(@"0 -544 -542 -545 -294 -1
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
                                           WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a19acc35c48f3c96d7decb3676d869210ab0aed18983", async() => {
                WriteLiteral(@"
                        <div class=""index-drop-down-menu-flex-container-img"">
                            <svg version=""1.0"" xmlns=""http://www.w3.org/2000/svg""
                                 width=""512.000000pt"" height=""512.000000pt"" viewBox=""0 0 512.000000 512.000000""
                                 preserveAspectRatio=""xMidYMid meet"">

                                <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)""
                                   fill=""#000000"" stroke=""none"">
                                    <path d=""M1770 5109 c-201 -26 -461 -104 -634 -191 -623 -313 -1042 -899
                                -1126 -1578 -15 -125 -12 -405 5 -529 64 -442 265 -841 582 -1157 224 -223
                                468 -375 777 -483 610 -214 1321 -105 1852 285 l71 52 724 -725 c398 -399 742
                                -738 763 -754 29 -22 50 -29 84 -29 44 0 48 3 149 103 100 101 103 105 103
                                149 0 34 -7 55 -29 84 -16 21 -355 365 -754");
                WriteLiteral(@" 763 l-725 724 52 71 c170 232 292
                                507 350 788 138 671 -66 1356 -548 1841 -316 317 -715 518 -1157 582 -115 16
                                -425 19 -539 4z m513 -444 c512 -81 970 -430 1188 -903 282 -612 156 -1316
                                -321 -1792 -626 -627 -1626 -626 -2251 2 -238 240 -389 535 -446 870 -19 115
                                -21 375 -4 478 63 371 216 669 472 916 277 266 611 416 999 448 74 6 269 -4
                                363 -19z"" />
                                </g>
                            </svg>
                        </div>
                        <p>Details</p>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 109 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
                                              WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n        </tr>\r\n");
#nullable restore
#line 134 "C:\OASIS\Views\ApprovalStatus\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OASIS.Models.ApprovalStatus>> Html { get; private set; }
    }
}
#pragma warning restore 1591
