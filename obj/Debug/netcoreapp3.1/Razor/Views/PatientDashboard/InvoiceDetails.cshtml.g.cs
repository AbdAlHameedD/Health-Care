#pragma checksum "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0aca5815085ad61790cd691c67b6888fc375dff9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PatientDashboard_InvoiceDetails), @"mvc.1.0.view", @"/Views/PatientDashboard/InvoiceDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0aca5815085ad61790cd691c67b6888fc375dff9", @"/Views/PatientDashboard/InvoiceDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08a5296f7959ee52362a7928c2c585f85abe7487", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PatientDashboard_InvoiceDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Health_Care_V1._2.Models.InvoiceItem>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dashboard/assets/js/pdf-invoice.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
  
    Layout = "~/Views/Shared/_PatientDashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script src=""https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.1/html2pdf.bundle.js"" integrity=""sha512-vNrhFyg0jANLJzCuvgtlfTuPR21gf5Uq1uuSs/EcBfVOz6oAHmjqfyPoB5rc9iWGSnVE41iuQU4jmpXMyhBrsw=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>

<div style=""margin: 50px;"" id=""invoice"">
    <div class=""row"">

        <!-- Logo -->
        <div class=""col-md-2 justify-content-center d-flex"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0aca5815085ad61790cd691c67b6888fc375dff94373", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 571, "~/images/", 571, 9, true);
#nullable restore
#line 14 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
AddHtmlAttributeValue("", 580, ViewBag.MainTable.LogoPath, 580, 27, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>

        <div class=""col-md-10 d-flex flex-wrap"" id=""cli"">

            <!-- Clinic Information -->
            <div class=""col-md-6"">
                <ul class=""lll-1"">
                    <!-- Clinic Name -->
                    <li>
                        <h3 style=""font-weight: bold; font-family: Verdana, Geneva, Tahoma, sans-serif;"">
                            ");
#nullable restore
#line 25 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                       Write(ViewBag.Clinic.ClinicName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h3>\r\n                    </li>\r\n                \r\n                    <!-- Clinic Addresses -->\r\n\r\n");
#nullable restore
#line 31 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                     if (!(ViewBag.ClinicAddresses is null))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                         foreach (var item in ViewBag.ClinicAddresses)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                ");
#nullable restore
#line 36 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                           Write(item.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 36 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                          Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 36 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                                      Write(item.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                 if(!(item.BuildingNumber is null))
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                               Write(item.BuildingNumber);

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                                        
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n");
#nullable restore
#line 43 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <!-- Clinic Phone Number -->\r\n");
#nullable restore
#line 47 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                     if (!(ViewBag.ClinicPhoneNumber is null))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>");
#nullable restore
#line 49 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                       Write(ViewBag.ClinicPhoneNumber.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 50 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </ul>
            </div>

            <!-- Invoice Information -->
            <div class=""col-md-6 d-flex justify-content-end align-items-center"">
                <ul class=""lll-1"">

                    <!-- Invoice Creation Date -->
                    <li>
                        Date: ");
#nullable restore
#line 60 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                         Write(ViewBag.Invoice.CreationDate.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </li>\r\n                    \r\n                    <!-- Invoice id -->\r\n                    <li>\r\n                        Invoice ID: <bold>");
#nullable restore
#line 65 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                     Write(ViewBag.Invoice.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</bold>
                    </li>
                </ul>
                
            </div>

        </div>
    </div>
    <hr />
    <div class=""row"">
        <div class=""col-md-6 justify-content-start"">
            <ul class=""lll-2"">
                <li>Patient Name</li>
                <li>Age</li>
");
#nullable restore
#line 79 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                 if (!(@ViewBag.PatientAddress is null))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>Patient Address</li>\r\n");
#nullable restore
#line 82 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 84 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                 if (!(@ViewBag.PatientPhoneNumber is null))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>Patient Phone Number</li>\r\n");
#nullable restore
#line 87 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                
                <li>Patient Email</li>
            </ul>
        </div>

        <div class=""col-md-6 justify-content-end"">
            <ul class=""lll-2"">
                
                <!-- Patient Full Name -->
                <li>");
#nullable restore
#line 97 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
               Write(ViewBag.Patient.Fname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 97 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                      Write(ViewBag.Patient.Mname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 97 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                                             Write(ViewBag.Patient.Lname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\r\n                <!-- Patient Age -->\r\n                <li>\r\n");
#nullable restore
#line 101 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                      
                        var age = DateTime.Now.Year - ViewBag.Patient.Bod.Year;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 104 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
               Write(age);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </li>\r\n\r\n                <!-- Patient Address -->\r\n");
#nullable restore
#line 108 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                 if (!(@ViewBag.PatientAddress is null))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>\r\n                        ");
#nullable restore
#line 111 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                   Write(ViewBag.PatientAddress.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 112 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                         if (!(ViewBag.PatientAddress.City is null))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>, </span>\r\n");
#nullable restore
#line 115 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                       Write(ViewBag.PatientAddress.City);

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                                        
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
#nullable restore
#line 118 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 120 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                 if (!(@ViewBag.PatientPhoneNumber is null))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 122 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                   Write(ViewBag.PatientPhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 123 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <!-- Patient Email -->\r\n                <li>");
#nullable restore
#line 126 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
               Write(ViewBag.Patient.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
            </ul>
        </div>
    </div>
    <hr />

    <table class=""table-responsive"" style=""width: 100%;"" id=""example"">
        <thead class=""inv-thead"">
            <tr>
                <th>ID</th>
                <th>Item Name</th>
                <th>Item Description</th>
                <th>Item Quantity</th>
                <th>Item Price</th>
            </tr>
        </thead>

        <tbody>
");
#nullable restore
#line 144 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
             foreach (var item in @Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <!-- ID -->\r\n                    <td>");
#nullable restore
#line 148 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <!-- Item Name -->\r\n                    <td>");
#nullable restore
#line 151 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                   Write(item.ItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <!-- Item Description -->\r\n                    <td>");
#nullable restore
#line 154 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                   Write(item.ItemDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <!-- Item Quantity -->\r\n                    <td>");
#nullable restore
#line 157 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                   Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <!-- Item Price -->\r\n                    <td>");
#nullable restore
#line 160 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 162 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <tr>\r\n                <td colspan=\"4\" style=\"font-size:2rem; font-weight:bold; letter-spacing: 3px;\">\r\n                    Total\r\n                </td>\r\n                <td style=\"font-size:2rem; font-weight:bold;\">\r\n                    ");
#nullable restore
#line 169 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
               Write(ViewBag.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </td>
            </tr>
        </tbody>
    </table>

    <div class=""row"" style=""margin: 50px;"">

        <div class=""col-md-6"">
            <h6>Doctor Note:</h6>
            <!-- Note Textarea -->
            <textarea class=""invoice-note col-md-11"" disabled >");
#nullable restore
#line 180 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
                                                          Write(ViewBag.Invoice.Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n        </div>\r\n\r\n        <div class=\"col-md-6 d-flex justify-content-end flex-column\">\r\n");
#nullable restore
#line 184 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
             if (@ViewBag.Invoice.Status == "UNPAID")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <!-- Pay -->\r\n                <div class=\"row justify-content-end align-items-center\" style=\"margin-bottom: 15px;\">\r\n                    <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6334, "\"", 6436, 3);
            WriteAttributeValue("", 6344, "location.href=\'", 6344, 15, true);
#nullable restore
#line 188 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
WriteAttributeValue("", 6359, Url.Action("Rate", "PatientDashboard", new {invoiceId=@ViewBag.Invoice.Id}), 6359, 76, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6435, "\'", 6435, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Pay</button>\r\n                </div>                \r\n");
#nullable restore
#line 190 "C:\Users\dabda\OneDrive\Desktop\Health-Care-V1.4\Views\PatientDashboard\InvoiceDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <!-- Download -->
            <div class=""row justify-content-end"">
                <button class=""btn btn-dark"" id=""download"" >Download</button>
            </div>
            
        </div>
    </div>

    <hr />
    <div class=""row justify-content-center"">
        <h6>Thank you</h6>
    </div>
    <hr />
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0aca5815085ad61790cd691c67b6888fc375dff923134", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Health_Care_V1._2.Models.InvoiceItem>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591