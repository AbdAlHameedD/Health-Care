#pragma checksum "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "571892d24948aa40b568c0dc100cfd3c2278adfb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clinics_Details), @"mvc.1.0.view", @"/Views/Clinics/Details.cshtml")]
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
#line 1 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\_ViewImports.cshtml"
using Health_Care_V1._2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\_ViewImports.cshtml"
using Health_Care_V1._2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571892d24948aa40b568c0dc100cfd3c2278adfb", @"/Views/Clinics/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08a5296f7959ee52362a7928c2c585f85abe7487", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Clinics_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Health_Care_V1._2.Models.Clinic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("128"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("128"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
  
    Layout = "~/Views/Shared/_AdminDashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"view-header\">Details</h1>\r\n\r\n<div>\r\n    <h6>Clinic ID: ");
#nullable restore
#line 10 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
              Write(ViewBag.ClinicId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ClinicName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
       Write(Html.DisplayFor(model => model.ClinicName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Addresses\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            <ol type=\"1\" style=\"padding-left: 16px;\">\r\n");
#nullable restore
#line 24 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                 foreach (var address in ViewBag.Addresses)
                {
                    var addr = address.Country + ", " + address.City + ", " + address.Street;
                    if (!(address.BuildingNumber is null))
                    {
                        addr += ", " + address.BuildingNumber;
                    }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 32 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                   Write(addr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 33 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                 if(ViewBag.Addresses.Count == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>No Data</li>\r\n");
#nullable restore
#line 37 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ol>\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Phone Numbers\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            <ol type=\"1\" style=\"padding-left: 16px;\">\r\n");
#nullable restore
#line 45 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                 foreach (var phoneNumber in ViewBag.PhoneNumbers)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 47 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                   Write(phoneNumber.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 48 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                 if(ViewBag.PhoneNumbers.Count == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>No Data</li>\r\n");
#nullable restore
#line 52 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ol>\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdditionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
       Write(Html.DisplayFor(model => model.AdditionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ClinicLogo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "571892d24948aa40b568c0dc100cfd3c2278adfb10051", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2067, "~/images/clinics-logo/", 2067, 22, true);
#nullable restore
#line 65 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
AddHtmlAttributeValue("", 2089, Model.ClinicLogo, 2089, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "571892d24948aa40b568c0dc100cfd3c2278adfb11768", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\Clinics\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "571892d24948aa40b568c0dc100cfd3c2278adfb13909", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Health_Care_V1._2.Models.Clinic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
