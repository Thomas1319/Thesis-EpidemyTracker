#pragma checksum "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b8abac83d5816f28473efb5a2ebb0c32a8a161b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditPatient), @"mvc.1.0.view", @"/Views/Admin/EditPatient.cshtml")]
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
#line 1 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\_ViewImports.cshtml"
using VirusTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\_ViewImports.cshtml"
using VirusTracker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b8abac83d5816f28473efb5a2ebb0c32a8a161b", @"/Views/Admin/EditPatient.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7e58ad8c1f818a123c28baee9eda5bae107f2e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditPatient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaveChangesPatient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
  
    ViewData["Title"] = "EditPatient";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    $(document).ready(function () {\r\n        $(\'#toFade\').delay(3000).fadeOut();\r\n    });\r\n</script>\r\n");
#nullable restore
#line 11 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
 if (TempData["editPatientCheck"] != "fail" && TempData["editPatientCheck"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show mt-3\" tabindex=\"-1\" role=\"alert\" id=\"toFade\">\r\n        <strong>");
#nullable restore
#line 14 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
           Write(TempData["editPatientCheck"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> edited successfully!\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 19 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
}
else if (TempData["editPatientCheck"] == "fail")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""alert alert-danger alert-dismissible fade show mt-3"" tabindex=""-1"" role=""alert"" id=""toFade"">
        Your requests did not go through.
        <hr />
        Please check it again!
        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
        </button>
    </div>
");
#nullable restore
#line 30 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
 if (TempData["removePatientCheck"] == "success")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""alert alert-success alert-dismissible fade show mt-3"" tabindex=""-1"" role=""alert"" id=""toFade"">
        Doctor has been removed successfully
        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
        </button>
    </div>
");
#nullable restore
#line 39 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <div class=\"card mt-3 mb-3\">\r\n");
#nullable restore
#line 42 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
         if (Model.Patient.gender == "Male")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2 class=\"card-title\"> Mr. ");
#nullable restore
#line 44 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
                                   Write(Model.Patient.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 44 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
                                                            Write(Model.Patient.lastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 45 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2 class=\"card-title\"> Ms. ");
#nullable restore
#line 48 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
                                   Write(Model.Patient.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 48 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
                                                            Write(Model.Patient.lastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 49 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"card-body\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b8abac83d5816f28473efb5a2ebb0c32a8a161b8746", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1970, "\"", 1995, 1);
#nullable restore
#line 53 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 1978, Model.Patient.ID, 1978, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <div class=\"form-group\">\r\n                    <label for=\"fname\">First Name:</label>\r\n                    <input type=\"text\" id=\"fname\" name=\"fname\"");
                BeginWriteAttribute("value", " value=\"", 2165, "\"", 2197, 1);
#nullable restore
#line 56 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 2173, Model.Patient.firstName, 2173, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"lname\">Last Name:</label>\r\n                    <input type=\"text\" id=\"lname\" name=\"lname\"");
                BeginWriteAttribute("value", " value=\"", 2420, "\"", 2451, 1);
#nullable restore
#line 60 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 2428, Model.Patient.lastName, 2428, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"username\">Address:</label>\r\n                    <input type=\"text\" id=\"address\" name=\"address\"");
                BeginWriteAttribute("value", " value=\"", 2679, "\"", 2709, 1);
#nullable restore
#line 64 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 2687, Model.Patient.address, 2687, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"password\">Age:</label>\r\n                    <input type=\"text\" id=\"age\" name=\"age\"");
                BeginWriteAttribute("value", " value=\"", 2925, "\"", 2951, 1);
#nullable restore
#line 68 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 2933, Model.Patient.age, 2933, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"email\">Email:</label>\r\n                    <input type=\"text\" id=\"email\" name=\"email\"");
                BeginWriteAttribute("value", " value=\"", 3170, "\"", 3205, 1);
#nullable restore
#line 72 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 3178, Model.Patient.emailAddress, 3178, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"phone\">Phone Number:</label>\r\n                    <input type=\"text\" id=\"phone\" name=\"phone\"");
                BeginWriteAttribute("value", " value=\"", 3431, "\"", 3465, 1);
#nullable restore
#line 76 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 3439, Model.Patient.phoneNumber, 3439, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"phone\">Weight:</label>\r\n                    <input type=\"text\" id=\"weight\" name=\"weight\"");
                BeginWriteAttribute("value", " value=\"", 3687, "\"", 3716, 1);
#nullable restore
#line 80 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 3695, Model.Patient.weight, 3695, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"phone\">Height:</label>\r\n                    <input type=\"text\" id=\"height\" name=\"height\"");
                BeginWriteAttribute("value", " value=\"", 3938, "\"", 3967, 1);
#nullable restore
#line 84 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 3946, Model.Patient.height, 3946, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"phone\">Symptoms:</label>\r\n                    <input type=\"text\" id=\"symptoms\" name=\"symptoms\"");
                BeginWriteAttribute("value", " value=\"", 4195, "\"", 4226, 1);
#nullable restore
#line 88 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 4203, Model.Patient.symptoms, 4203, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"phone\">Treatment:</label>\r\n                    <input type=\"text\" id=\"treatment\" name=\"treatment\"");
                BeginWriteAttribute("value", " value=\"", 4457, "\"", 4489, 1);
#nullable restore
#line 92 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 4465, Model.Patient.treatment, 4465, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <input class=\"btn btn-info\" type=\"submit\" title=\"Edit\" value=\"edit\" />\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n\r\n");
#nullable restore
#line 100 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
     if (Model.Patient.doctorId != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table"">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Code</th>
                </tr>

            </thead>
            <tbody>
                <tr>
                    <td>");
#nullable restore
#line 113 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
                   Write(Model.Doctor.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 114 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
                   Write(Model.Doctor.lastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>ABC123</td>\r\n                    <td>\r\n                        <input class=\"btn btn-info\" type=\"button\" title=\"View\" value=\"View\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5280, "\"", 5367, 3);
            WriteAttributeValue("", 5290, "location.href=\'", 5290, 15, true);
#nullable restore
#line 117 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 5305, Url.Action("EditDoctor", new { doctorId = Model.Doctor.Id }), 5305, 61, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5366, "\'", 5366, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </td>\r\n                    <td>\r\n                        <input class=\"btn btn-danger\" type=\"button\" title=\"Remove\" value=\"Remove\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5523, "\"", 5615, 3);
            WriteAttributeValue("", 5533, "location.href=\'", 5533, 15, true);
#nullable restore
#line 120 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
WriteAttributeValue("", 5548, Url.Action("RemoveFromPatient", new { patId = Model.Patient.ID }), 5548, 66, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5614, "\'", 5614, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n\r\n            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 126 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\EditPatient.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n</div>\r\n\r\n");
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
