#pragma checksum "C:\Users\Asus\Source\Repos\OASIS\Views\Projects\_AddCustomerModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e204db3ca8f6e9abf5c0c1f5c51f930c8eca64a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects__AddCustomerModal), @"mvc.1.0.view", @"/Views/Projects/_AddCustomerModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e204db3ca8f6e9abf5c0c1f5c51f930c8eca64a", @"/Views/Projects/_AddCustomerModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3302f6a14086a54b22723668626e6de41fec1da1", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects__AddCustomerModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CustomerCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Modal-->
<div class=""modal fade"" id=""addCustomerModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""myModalLabel"">Add Customer</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
            </div>
            <div class=""modal-body"">
");
#nullable restore
#line 10 "C:\Users\Asus\Source\Repos\OASIS\Views\Projects\_AddCustomerModal.cshtml"
                   var c = new OASIS.Models.Customer();

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7e204db3ca8f6e9abf5c0c1f5c51f930c8eca64a4191", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 11 "C:\Users\Asus\Source\Repos\OASIS\Views\Projects\_AddCustomerModal.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = c;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"            </div>
        </div>
    </div>
</div>
<div style=""display:flex; margin-top:50px; margin-bottom:20px;"">
    <button type=""submit"" style=""width: 6%;margin-right:3.5%;"" class=""button-menu form-group btn btn-success"" data-toggle=""tooltip"" data-placement=""top"" title=""Save Customer"">
        <div style=""width:20px; height:22px;"">
            <svg version=""1.0"" xmlns=""http://www.w3.org/2000/svg"" width=""512.000000pt"" height=""512.000000pt"" viewBox=""0 0 512.000000 512.000000"" preserveAspectRatio=""xMidYMid meet"">

                <g transform=""translate(0.000000,512.000000) scale(0.100000,-0.100000)"" fill=""white"" stroke=""none"">
                    <path d=""M66 5101 c-15 -10 -37 -32 -47 -47 -18 -28 -19 -96 -19 -2494 0
                                -2398 1 -2466 19 -2494 10 -15 32 -37 47 -47 28 -18 96 -19 2494 -19 2398 0
                                2466 1 2494 19 15 10 37 32 47 47 18 28 19 88 19 2095 l0 2066 -29 39 c-34 46
                                -805 814 -841 838 -21 14 -64 16 -33");
            WriteLiteral(@"2 16 l-307 0 -3 -742 -3 -743 -22 -35
                                c-12 -19 -37 -44 -55 -55 -33 -20 -51 -20 -1268 -20 l-1235 0 -35 22 c-19 12
                                -44 37 -55 55 -19 32 -20 53 -23 776 l-3 742 -407 0 c-382 0 -409 -1 -436 -19z
                                m3844 -3751 l0 -1050 -1350 0 -1350 0 0 1050 0 1050 1350 0 1350 0 0 -1050z""></path>
                    <path d=""M1576 2081 c-46 -31 -66 -69 -66 -131 0 -62 20 -100 66 -131 28 -18
                                65 -19 984 -19 919 0 956 1 984 19 46 31 66 69 66 131 0 62 -20 100 -66 131
                                -28 18 -65 19 -984 19 -919 0 -956 -1 -984 -19z""></path>
                    <path d=""M1576 1481 c-46 -31 -66 -69 -66 -131 0 -62 20 -100 66 -131 28 -18
                                65 -19 984 -19 919 0 956 1 984 19 46 31 66 69 66 131 0 62 -20 100 -66 131
                                -28 18 -65 19 -984 19 -919 0 -956 -1 -984 -19z""></path>
                    <path d=""M1576 881 c-46 -31 -66 -69 -66 -131 0 -");
            WriteLiteral(@"62 20 -100 66 -131 28 -18
                                65 -19 984 -19 919 0 956 1 984 19 46 31 66 69 66 131 0 62 -20 100 -66 131
                                -28 18 -65 19 -984 19 -919 0 -956 -1 -984 -19z""></path>
                    <path d=""M1210 4470 l0 -650 1050 0 1050 0 0 650 0 650 -1050 0 -1050 0 0
                                -650z""></path>
                </g>
            </svg>

        </div>

    </button>
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
