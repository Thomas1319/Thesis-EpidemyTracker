#pragma checksum "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d243d148414a336ce136d4ead3d427d376a30bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d243d148414a336ce136d4ead3d427d376a30bb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7e58ad8c1f818a123c28baee9eda5bae107f2e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""text-center"">
        <h1 class=""display-4"">Welcome</h1>

        <p>Welcome to the Epidemy Tracker! This app is here to come to your help during this difficult times when social distancing is necessary for your safety. We want to offer you a way of getting quality medical guidance from the safety and comfort of you home, so you won't need to go to a medical office and risk spreading or receiving the new virus that has brought the whole world in a state of emergency. </p>


        <p>If you are a medical specialist and you want to help us, feel free to contact us with any kind of questions regarding the system. When you make a decision, please go to the Enroll page in order to start the process.</p>
        <h5>I am a</h5>

        <a class=""btn btn-primary"" href=""https://localhost:5001"">Patient</a>
        <a class=""btn btn-primary""");
            BeginWriteAttribute("href", " href=\"", 919, "\"", 957, 1);
#nullable restore
#line 15 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Home\Index.cshtml"
WriteAttributeValue("", 926, Url.Action("Login", "Account"), 926, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Doctor</a>\r\n    </div>\r\n");
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
