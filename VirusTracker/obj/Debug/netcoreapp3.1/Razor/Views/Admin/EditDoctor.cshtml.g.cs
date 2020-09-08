#pragma checksum "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3c8d439352e87eb252cef2a650f9aeb6b913fb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditDoctor), @"mvc.1.0.view", @"/Views/Admin/EditDoctor.cshtml")]
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
#line 1 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\_ViewImports.cshtml"
using VirusTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\_ViewImports.cshtml"
using VirusTracker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3c8d439352e87eb252cef2a650f9aeb6b913fb0", @"/Views/Admin/EditDoctor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7e58ad8c1f818a123c28baee9eda5bae107f2e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditDoctor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaveChangesDoctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
  
    ViewData["Title"] = "EditDoctor";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
 if (TempData["editDoctorCheck"] != "fail" && TempData["editDoctorCheck"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show mt-3\" tabindex=\"-1\" role=\"alert\" id=\"toFade\">\r\n        <strong>");
#nullable restore
#line 9 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
           Write(TempData["editDoctorCheck"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> edited successfully!\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 14 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
}
else if (TempData["editDoctorCheck"] == "fail")
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
#line 25 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
}
else if (TempData["removeDoctorCheck"] == "success")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""alert alert-success alert-dismissible fade show mt-3"" tabindex=""-1"" role=""alert"" id=""toFade"">
        Patient has been removed successfully!
        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
        </button>
    </div>
");
#nullable restore
#line 34 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <div class=\"card mt-4\">\r\n        <div class=\"card-header bg-primary border-bottom\">\r\n            <div class=\"row\">\r\n                <h4 class=\"ml-2 text-white\"> Dr. ");
#nullable restore
#line 39 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                                            Write(Model.Doctor.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 39 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                                                                    Write(Model.Doctor.lastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            </div>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3c8d439352e87eb252cef2a650f9aeb6b913fb07229", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1785, "\"", 1809, 1);
#nullable restore
#line 44 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 1793, Model.Doctor.Id, 1793, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <div class=\"form-group\">\r\n                    <label for=\"fname\">First Name:</label>\r\n                    <input type=\"text\" id=\"fname\" name=\"fname\"");
                BeginWriteAttribute("value", " value=\"", 1979, "\"", 2010, 1);
#nullable restore
#line 47 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 1987, Model.Doctor.firstName, 1987, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"lname\">Last Name:</label>\r\n                    <input type=\"text\" id=\"lname\" name=\"lname\"");
                BeginWriteAttribute("value", " value=\"", 2233, "\"", 2263, 1);
#nullable restore
#line 51 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 2241, Model.Doctor.lastName, 2241, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"username\">Username:</label>\r\n                    <input type=\"text\" id=\"username\" name=\"username\"");
                BeginWriteAttribute("value", " value=\"", 2494, "\"", 2524, 1);
#nullable restore
#line 55 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 2502, Model.Doctor.UserName, 2502, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"password\">Password:</label>\r\n                    <input type=\"text\" id=\"password\" name=\"password\"");
                BeginWriteAttribute("value", " value=\"", 2755, "\"", 2785, 1);
#nullable restore
#line 59 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 2763, Model.Doctor.password, 2763, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"email\">Email:</label>\r\n                    <input type=\"text\" id=\"email\" name=\"email\"");
                BeginWriteAttribute("value", " value=\"", 3004, "\"", 3031, 1);
#nullable restore
#line 63 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 3012, Model.Doctor.Email, 3012, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label for=\"phone\">Phone Number:</label>\r\n                    <input type=\"text\" id=\"phone\" name=\"phone\"");
                BeginWriteAttribute("value", " value=\"", 3257, "\"", 3290, 1);
#nullable restore
#line 67 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 3265, Model.Doctor.PhoneNumber, 3265, 25, false);

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
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 74 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
     if (Model.Patients.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""card mt-4"">
            <div class=""card-header bg-primary border-bottom"">
                <div class=""row"">
                    <h5 class=""ml-2 text-white"">Doctor's patients</h5>
                </div>
            </div> 
            <div class=""card-body"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <td>First name</td>
                            <td>Last name</td>
                            <td>Status</td>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 92 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                         foreach (Patient p in Model.Patients)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 95 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                               Write(p.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 96 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                               Write(p.lastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 97 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                                 if (DateTime.Compare(p.quarantineEndDate, DateTime.Parse("13/02/1999")) > 0 || DateTime.Compare(p.quarantineEndDate, DateTime.Now) > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class=\"text-danger\">Sick</td>\r\n");
#nullable restore
#line 100 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class=\"text-success\">Healthy</td>\r\n");
#nullable restore
#line 104 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    <input class=\"btn btn-info\" type=\"button\" title=\"View\" value=\"view\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5017, "\"", 5095, 3);
            WriteAttributeValue("", 5027, "location.href=\'", 5027, 15, true);
#nullable restore
#line 106 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 5042, Url.Action("EditPatient", new { patientId = p.ID }), 5042, 52, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5094, "\'", 5094, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </td>\r\n                                <td>\r\n                                    <input class=\"btn btn-danger\" type=\"button\" title=\"Remove\" value=\"remove\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5287, "\"", 5395, 3);
            WriteAttributeValue("", 5297, "location.href=\'", 5297, 15, true);
#nullable restore
#line 109 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
WriteAttributeValue("", 5312, Url.Action("RemoveFromDoctor", new { patientId = p.ID, docId = Model.Doctor.Id }), 5312, 82, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5394, "\'", 5394, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 112 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 117 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\EditDoctor.cshtml"
        
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
