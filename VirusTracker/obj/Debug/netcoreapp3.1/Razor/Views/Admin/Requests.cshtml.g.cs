#pragma checksum "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e0b872fd0cd898da8802813cc8e6e9c053bae7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Requests), @"mvc.1.0.view", @"/Views/Admin/Requests.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e0b872fd0cd898da8802813cc8e6e9c053bae7b", @"/Views/Admin/Requests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7e58ad8c1f818a123c28baee9eda5bae107f2e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Requests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EnrollModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
  
    ViewData["Title"] = "Requests";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    $(document).ready(function () {\r\n        $(\'#toFade\').delay(3000).fadeOut();\r\n    });\r\n</script>\r\n");
#nullable restore
#line 11 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
 if (TempData["requestCheck"] != null && TempData["requestCheck"] != "fail")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show mt-3\" tabindex=\"-1\" role=\"alert\" id=\"toFade\">\r\n        ");
#nullable restore
#line 14 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
   Write(TempData["requestCheck"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 19 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
}
else if (TempData["requestCheck"] == "fail")
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""alert alert-danger alert-dismissible fade show mt-3"" tabindex=""-1"" role=""alert"">
        Your requests did not go through.
        <hr />
        Please check it again!
        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
        </button>
    </div>
");
#nullable restore
#line 31 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>Requests</h1>
<table class=""table"">
    <thead>
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email Address</th>
            <th>CV</th>
            <th>Letter</th>
        </tr>

    </thead>
    <tbody>
");
#nullable restore
#line 45 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
          
            foreach (var e in Model)
            {
                if (e.status == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 51 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
                       Write(Html.DisplayFor(modelItem => e.firstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 52 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
                       Write(Html.DisplayFor(modelItem => e.lastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 53 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
                       Write(e.emailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1727, "\"", 1802, 1);
#nullable restore
#line 55 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
WriteAttributeValue("", 1734, Url.Action("GetDocument", "Admin", new{document = "CV", id = e.Id}), 1734, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">description</i></a>\r\n                        </td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1942, "\"", 2021, 1);
#nullable restore
#line 58 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
WriteAttributeValue("", 1949, Url.Action("GetDocument", "Admin", new{document = "Letter", id = e.Id}), 1949, 72, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"material-icons\">description</i></a>\r\n                        </td>\r\n                        <td>\r\n                            <input class=\"btn btn-danger\" type=\"button\" title=\"Approve\" value=\"Approve\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2234, "\"", 2306, 3);
            WriteAttributeValue("", 2244, "location.href=\'", 2244, 15, true);
#nullable restore
#line 61 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
WriteAttributeValue("", 2259, Url.Action("ApproveDoctor", new {id = e.Id }), 2259, 46, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2305, "\'", 2305, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                            <input class=\"btn btn-danger\" type=\"button\" title=\"Deny\" value=\"Deny\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2470, "\"", 2539, 3);
            WriteAttributeValue("", 2480, "location.href=\'", 2480, 15, true);
#nullable restore
#line 64 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
WriteAttributeValue("", 2495, Url.Action("DenyDoctor", new { id = e.Id}), 2495, 43, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2538, "\'", 2538, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 67 "D:\VS projects\Visual Studio proj\Thesis\VirusTracker\Views\Admin\Requests.cshtml"
                }


            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EnrollModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
