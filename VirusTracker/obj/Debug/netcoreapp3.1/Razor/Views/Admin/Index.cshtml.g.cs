#pragma checksum "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "918c7d848228dd594c1f70ce113fd92a690d7892"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"918c7d848228dd594c1f70ce113fd92a690d7892", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7e58ad8c1f818a123c28baee9eda5bae107f2e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
    List< Patient > patients = Model.Patients;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h3>Doctors</h3>
    <table class=""table"">
        <thead>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Code</th>
                <th>Number of Patients</th>
                <th>Sick</th>
                <th>Healthy</th>
            </tr>

        </thead>
        <tbody>
");
#nullable restore
#line 21 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
              
                foreach (Doctor d in Model.Doctors)
                {
                    int nbOfPatients = patients.Count(p => p.doctorId == d.Id);
                    int sick= patients.Count(p => (DateTime.Compare(p.quarantineEndDate, DateTime.Parse("13/02/1999")) > 0 || DateTime.Compare(p.quarantineEndDate, DateTime.Now) > 0) && p.doctorId == d.Id);
                    int healthy = nbOfPatients - sick;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 28 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => d.firstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 29 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => d.lastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>ABC123</td>\r\n                            <td>");
#nullable restore
#line 31 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
                           Write(nbOfPatients);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-danger\">");
#nullable restore
#line 32 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
                                               Write(sick);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-success\">");
#nullable restore
#line 33 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
                                                Write(healthy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <input class=\"btn btn-info\" type=\"button\" title=\"Edit\" value=\"edit\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1497, "\"", 1573, 3);
            WriteAttributeValue("", 1507, "location.href=\'", 1507, 15, true);
#nullable restore
#line 35 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1522, Url.Action("EditDoctor", new { doctorId = d.Id }), 1522, 50, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1572, "\'", 1572, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            </td>\r\n                            <td>\r\n                                <input class=\"btn btn-danger\" type=\"button\" title=\"Remove\" value=\"Remove\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1753, "\"", 1831, 3);
            WriteAttributeValue("", 1763, "location.href=\'", 1763, 15, true);
#nullable restore
#line 38 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1778, Url.Action("RemoveDoctor", new { doctorId = d.Id }), 1778, 52, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1830, "\'", 1830, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 41 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Index.cshtml"
                
            }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n");
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
