#pragma checksum "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\Rate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "805407ba373b0700d1970f5c6f1d8c4b9f301613"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PatientDashboard_Rate), @"mvc.1.0.view", @"/Views/PatientDashboard/Rate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"805407ba373b0700d1970f5c6f1d8c4b9f301613", @"/Views/PatientDashboard/Rate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08a5296f7959ee52362a7928c2c585f85abe7487", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PatientDashboard_Rate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Health_Care_V1._2.Models.Invoice>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid doc-profile-pic-"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("150"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("150"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\Rate.cshtml"
  
    Layout = "~/Views/Shared/_PatientDashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"view-header\">Rate Our Services</h1>\r\n\r\n<div class=\"row justify-content-around\" style=\"margin: 50px; padding: 50px;\">\r\n    <div class=\"col-md-4\">\r\n        <div class=\"doc-profile-pic-container\" >\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "805407ba373b0700d1970f5c6f1d8c4b9f3016134770", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 344, "~/images/clinics-logo/", 344, 22, true);
#nullable restore
#line 12 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\Rate.cshtml"
AddHtmlAttributeValue("", 366, ViewBag.Clinic.ClinicLogo, 366, 26, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 12 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\Rate.cshtml"
AddHtmlAttributeValue("", 399, ViewBag.Clinic.ClinicName, 399, 26, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue(" ", 425, "Logo", 426, 5, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n        <h5 class=\"d-flex justify-content-center\" >");
#nullable restore
#line 16 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\Rate.cshtml"
                                              Write(ViewBag.Clinic.ClinicName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <input class=\"d-block\" style=\"margin:auto;\" type=\"number\" name=\"clinicRate\" min=1 max=5 />\r\n    </div>\r\n\r\n    <div class=\"col-md-4\">\r\n        <div class=\"doc-profile-pic-container\" >\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "805407ba373b0700d1970f5c6f1d8c4b9f3016137657", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 825, "~/images/profile-pictures/", 825, 26, true);
#nullable restore
#line 22 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\Rate.cshtml"
AddHtmlAttributeValue("", 851, ViewBag.Doctor.ProfilePicture, 851, 30, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 22 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\Rate.cshtml"
AddHtmlAttributeValue("", 888, ViewBag.Doctor.ProfilePicture, 888, 30, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue(" ", 918, "Profile", 919, 8, true);
            AddHtmlAttributeValue(" ", 926, "Picture", 927, 8, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n        <h5 class=\"d-flex justify-content-center\">");
#nullable restore
#line 26 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\Rate.cshtml"
                                             Write(ViewBag.Doctor.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <input class=\"d-block\" style=\"margin:auto;\" type=\"number\" name=\"doctorRate\" min=1 max=5 />\r\n    </div>\r\n\r\n    <div \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Health_Care_V1._2.Models.Invoice> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
