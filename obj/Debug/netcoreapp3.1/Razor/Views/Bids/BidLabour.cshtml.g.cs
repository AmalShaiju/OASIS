#pragma checksum "C:\OASIS\Views\Bids\BidLabour.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78f836cb760fe1c6bbca60a97f76c8672e4781ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bids_BidLabour), @"mvc.1.0.view", @"/Views/Bids/BidLabour.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78f836cb760fe1c6bbca60a97f76c8672e4781ac", @"/Views/Bids/BidLabour.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_Bids_BidLabour : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin:0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("RoleID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "RoleID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""col-md-9 tab-pane fade"" id=""pills-bidLabour"" role=""tabpanel"" aria-labelledby=""pills-bidLabour-tab"">
    <div id=""bidRolesTable"" class=""container-table100 list-group"" style=""overflow-y: auto; height: 355px; margin-bottom: 2%;"">
        <div class=""wrap-table100"">
            <div class=""table100"">
                <table id=""BidLabourTable"">
                    <thead>
                        <tr class=""table100-head"">
                            <th class=""column1"">Role</th>
                            <th class=""column4"">Price </th>
                            <th class=""column5"">Hours</th>
                            <th class=""column6"">Total</th>
                            <th class=""column6 budget""></th>
                            <th class=""column6"" id=""bidRoleTotal""></th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 17 "C:\OASIS\Views\Bids\BidLabour.cshtml"
                         if (ViewBag.AssignedBidlabours != null)
                        {
                            foreach (var i in ViewBag.AssignedBidlabours)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr");
            BeginWriteAttribute("id", " id=", 1139, "", 1163, 2);
            WriteAttributeValue("", 1143, "labourRow-", 1143, 10, true);
#nullable restore
#line 21 "C:\OASIS\Views\Bids\BidLabour.cshtml"
WriteAttributeValue("", 1153, i.Role.ID, 1153, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <td class=\"column1\">");
#nullable restore
#line 22 "C:\OASIS\Views\Bids\BidLabour.cshtml"
                                                   Write(i.Role.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"column4\"");
            BeginWriteAttribute("id", " id=\"", 1296, "\"", 1323, 2);
            WriteAttributeValue("", 1301, "labourPrice-", 1301, 12, true);
#nullable restore
#line 23 "C:\OASIS\Views\Bids\BidLabour.cshtml"
WriteAttributeValue("", 1313, i.Role.ID, 1313, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">$");
#nullable restore
#line 23 "C:\OASIS\Views\Bids\BidLabour.cshtml"
                                                                                Write(i.Role.LabourPricePerHr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"column5\"><input type=\"text\" disabled");
            BeginWriteAttribute("id", " id=\"", 1440, "\"", 1465, 2);
            WriteAttributeValue("", 1445, "labourTxt-", 1445, 10, true);
#nullable restore
#line 24 "C:\OASIS\Views\Bids\BidLabour.cshtml"
WriteAttributeValue("", 1455, i.Role.ID, 1455, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1466, "\"", 1482, 1);
#nullable restore
#line 24 "C:\OASIS\Views\Bids\BidLabour.cshtml"
WriteAttributeValue("", 1474, i.Hours, 1474, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n                                    <td class=\"column6\"");
            BeginWriteAttribute("id", " id=\"", 1548, "\"", 1575, 2);
            WriteAttributeValue("", 1553, "labourTotal-", 1553, 12, true);
#nullable restore
#line 25 "C:\OASIS\Views\Bids\BidLabour.cshtml"
WriteAttributeValue("", 1565, i.Role.ID, 1565, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">$");
#nullable restore
#line 25 "C:\OASIS\Views\Bids\BidLabour.cshtml"
                                                                                 Write((double)i.Role.LabourPricePerHr * i.Hours);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"column7\"><input type=\"button\"");
            BeginWriteAttribute("id", " id=\"", 1705, "\"", 1731, 2);
            WriteAttributeValue("", 1710, "labourEdit-", 1710, 11, true);
#nullable restore
#line 26 "C:\OASIS\Views\Bids\BidLabour.cshtml"
WriteAttributeValue("", 1721, i.Role.ID, 1721, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\" onclick=\"labourEditRow(this.id)\" value=\"Edit\" /><input type=\"button\" style=\"display:none\"");
            BeginWriteAttribute("id", " id=\"", 1846, "\"", 1872, 2);
            WriteAttributeValue("", 1851, "labourSave-", 1851, 11, true);
#nullable restore
#line 26 "C:\OASIS\Views\Bids\BidLabour.cshtml"
WriteAttributeValue("", 1862, i.Role.ID, 1862, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\" onclick=\"labourSaveRow(this.id)\" value=\"Save\" /></td>\r\n                                    <td class=\"column7\"><input type=\"button\"");
            BeginWriteAttribute("id", " id=\"", 2029, "\"", 2057, 2);
            WriteAttributeValue("", 2034, "labourDelete-", 2034, 13, true);
#nullable restore
#line 27 "C:\OASIS\Views\Bids\BidLabour.cshtml"
WriteAttributeValue("", 2047, i.Role.ID, 2047, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\" onclick=\"labourDeleteRow(this.id)\" value=\"Delete\" /></td>\r\n                                </tr>\r\n");
#nullable restore
#line 29 "C:\OASIS\Views\Bids\BidLabour.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class=""input-group "" style=""margin-bottom:60px;"">

        <div class=""input-group mb-3"" style=""width:100%; margin:0px!important;"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78f836cb760fe1c6bbca60a97f76c8672e4781ac11077", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78f836cb760fe1c6bbca60a97f76c8672e4781ac11354", async() => {
                    WriteLiteral("select a Role");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 40 "C:\OASIS\Views\Bids\BidLabour.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.RoleID;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div class=""input-group-append"">
                <label style=""background:white;"" class=""input-group-text"" for=""inputGroupSelect02"">Hours</label>
            </div>
            <input style=""margin:0"" id=""roleHours"" type=""number"" class=""form-control"" placeholder=""Example: 2"" aria-label=""Quantity"" aria-describedby=""basic-addon1"">
            <button id=""btnAddRole"" class=""btn btn-outline-success"" type=""button"" data-toggle=""tooltip"" data-placement=""top"" title=""Add Labour"">+</button>
        </div>

    </div>
</div>
");
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
