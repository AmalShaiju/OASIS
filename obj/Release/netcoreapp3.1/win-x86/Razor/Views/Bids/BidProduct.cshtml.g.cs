#pragma checksum "C:\OASIS\Views\Bids\BidProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34e601c9d2a0c1ebf924c15f8750e05d5f1bc999"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bids_BidProduct), @"mvc.1.0.view", @"/Views/Bids/BidProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34e601c9d2a0c1ebf924c15f8750e05d5f1bc999", @"/Views/Bids/BidProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_Bids_BidProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ProductTypeID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ProductTypeID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin:0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ProductID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ProductID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""col-md-9 tab-pane fade"" id=""pills-contact"" role=""tabpanel"" aria-labelledby=""pills-contact-tab"">

    <div id=""bidProductTable"" class=""container-table100 list-group"" style=""overflow-y: auto; height: 355px; margin-bottom: 2%;"">

        <div class=""wrap-table100"">
            <div class=""table100"">
                <table id=""BidproductTable"">
                    <thead>
                        <tr class=""table100-head"">
                            <th class=""column1"">Code</th>
                            <th class=""column2"">Description </th>
                            <th class=""column3"">Size</th>
                            <th class=""column4"">Price</th>
                            <th class=""column5"">Quantity</th>
                            <th class=""column6"">Total</th>
                            <th class=""column6 budget"" ></th>
                            <th class=""column6"" id=""bidProductTotal""></th>
                        </tr>
                    </thead>
             ");
            WriteLiteral("       <tbody>\r\n");
#nullable restore
#line 21 "C:\OASIS\Views\Bids\BidProduct.cshtml"
                         if (ViewBag.AssignedBidProducts != null)
                        {
                            foreach (var item in ViewBag.AssignedBidProducts)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=", 1271, "", 1295, 2);
            WriteAttributeValue("", 1275, "row-", 1275, 4, true);
#nullable restore
#line 25 "C:\OASIS\Views\Bids\BidProduct.cshtml"
WriteAttributeValue("", 1279, item.Product.ID, 1279, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td class=\"column1\">");
#nullable restore
#line 26 "C:\OASIS\Views\Bids\BidProduct.cshtml"
                                           Write(item.Product.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"column2\">");
#nullable restore
#line 27 "C:\OASIS\Views\Bids\BidProduct.cshtml"
                                           Write(item.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"column3\">");
#nullable restore
#line 28 "C:\OASIS\Views\Bids\BidProduct.cshtml"
                                           Write(item.Product.size);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"column4\"");
            BeginWriteAttribute("id", " id=\"", 1571, "\"", 1598, 2);
            WriteAttributeValue("", 1576, "price-", 1576, 6, true);
#nullable restore
#line 29 "C:\OASIS\Views\Bids\BidProduct.cshtml"
WriteAttributeValue("", 1582, item.Product.ID, 1582, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">$");
#nullable restore
#line 29 "C:\OASIS\Views\Bids\BidProduct.cshtml"
                                                                        Write(item.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"column5\"><input type=\"number\" disabled");
            BeginWriteAttribute("id", " id=\"", 1704, "\"", 1729, 2);
            WriteAttributeValue("", 1709, "txt-", 1709, 4, true);
#nullable restore
#line 30 "C:\OASIS\Views\Bids\BidProduct.cshtml"
WriteAttributeValue("", 1713, item.Product.ID, 1713, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1730, "\"", 1752, 1);
#nullable restore
#line 30 "C:\OASIS\Views\Bids\BidProduct.cshtml"
WriteAttributeValue("", 1738, item.Quantity, 1738, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n                            <td class=\"column6\"");
            BeginWriteAttribute("id", "  id=\"", 1810, "\"", 1838, 2);
            WriteAttributeValue("", 1816, "total-", 1816, 6, true);
#nullable restore
#line 31 "C:\OASIS\Views\Bids\BidProduct.cshtml"
WriteAttributeValue("", 1822, item.Product.ID, 1822, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">$");
#nullable restore
#line 31 "C:\OASIS\Views\Bids\BidProduct.cshtml"
                                                                         Write(Math.Round((item.Quantity*item.Product.Price),2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"column7\"><input type=\"button\"");
            BeginWriteAttribute("id", " id=\"", 1965, "\"", 1991, 2);
            WriteAttributeValue("", 1970, "edit-", 1970, 5, true);
#nullable restore
#line 32 "C:\OASIS\Views\Bids\BidProduct.cshtml"
WriteAttributeValue("", 1975, item.Product.ID, 1975, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\" onclick=\"editRow(this.id)\" value=\"Edit\" /><input type=\"button\" style=\"display:none\"");
            BeginWriteAttribute("id", " id=\"", 2100, "\"", 2126, 2);
            WriteAttributeValue("", 2105, "save-", 2105, 5, true);
#nullable restore
#line 32 "C:\OASIS\Views\Bids\BidProduct.cshtml"
WriteAttributeValue("", 2110, item.Product.ID, 2110, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\" onclick=\"saveRow(this.id)\" value=\"Save\" /></td>\r\n                            <td class=\"column7\"><input type=\"button\"");
            BeginWriteAttribute("id", " id=\"", 2269, "\"", 2297, 2);
            WriteAttributeValue("", 2274, "delete-", 2274, 7, true);
#nullable restore
#line 33 "C:\OASIS\Views\Bids\BidProduct.cshtml"
WriteAttributeValue("", 2281, item.Product.ID, 2281, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\" onclick=\"deleteRow(this.id)\" value=\"Delete\" /></td>\r\n                        </tr>\r\n");
#nullable restore
#line 35 "C:\OASIS\Views\Bids\BidProduct.cshtml"
                            }

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n    <div class=\"input-group m-t-12\">\r\n        <div class=\"input-group-prepend\" style=\"background:White\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34e601c9d2a0c1ebf924c15f8750e05d5f1bc99912746", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34e601c9d2a0c1ebf924c15f8750e05d5f1bc99913023", async() => {
                    WriteLiteral("All Product Types");
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 47 "C:\OASIS\Views\Bids\BidProduct.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.ProductTypeID;

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
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"input-group mb-3\" style=\"width:79%; background:white; margin:0px!important;\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34e601c9d2a0c1ebf924c15f8750e05d5f1bc99915898", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34e601c9d2a0c1ebf924c15f8750e05d5f1bc99916175", async() => {
                    WriteLiteral("select a Product");
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 53 "C:\OASIS\Views\Bids\BidProduct.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.ProductID;

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
                <label class=""input-group-text"" for=""inputGroupSelect02"">Quantity</label>
            </div>
            <input style=""margin:0"" id=""ProductQuantity"" type=""number"" class=""form-control"" placeholder=""Example: 2"" aria-label=""Quantity"" aria-describedby=""basic-addon1"">
            <button id=""btnAddProduct"" class=""btn btn-outline-success"" type=""button"" data-toggle=""tooltip"" data-placement=""top"" title=""Add Product"">+</button>
        </div>

    </div>

</div>");
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
