#pragma checksum "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2780cc5b20697791eebc3d83552d60f687fc38ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Messages), @"mvc.1.0.view", @"/Views/Admin/Messages.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2780cc5b20697791eebc3d83552d60f687fc38ae", @"/Views/Admin/Messages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7e58ad8c1f818a123c28baee9eda5bae107f2e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Messages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Message>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AnswerInternal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Message", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AnswerExternal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
  
    ViewData["Title"] = "Messages";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    $(document).ready(function () {\r\n        $(\'#toFade\').delay(3000).fadeOut();\r\n    });\r\n</script>\r\n");
#nullable restore
#line 11 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
 if (TempData["messageCheck"] != "fail" && TempData["messageCheck"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show mt-3\" tabindex=\"-1\" role=\"alert\" id=\"toFade\">\r\n        ");
#nullable restore
#line 14 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
   Write(TempData["messageCheck"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 19 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
}
else if (TempData["messageCheck"] == "fail")
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
#line 30 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    function toggle(id1, id2) {
        x = document.getElementById(id1);
        y = document.getElementById(id2);
        x.style.display = ""none"";
        y.style.display = ""block"";
    }
</script>
<!--INTERNAL-->

<div id=""internal"" style=""display:block"">
    <div class=""row no-gutters mt-2"">
        <div class=""col-3"">
            <h3 class=""text-secondary"">Internal messages</h3>
        </div>
        <div class=""col-2"">
            <button class=""btn btn-info float-left"" type=""button"" onclick=""toggle('internal', 'external')"">Show External Messages</button>
        </div>
    </div>
    <hr />

");
#nullable restore
#line 52 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
      
        var intern = Model.FindAll(m => m.type.Trim() == "internal");
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
         if (intern.Count > 0)
        {
            var unanswered = intern.FindAll(m => m.answer == null);
            var answered = intern.FindAll(m => m.answer != null);
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
             if (unanswered.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4 class=\"text-info\">Unanswered</h4>\r\n");
#nullable restore
#line 61 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                foreach (var m in unanswered)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""card mb-3"">
                        <div class=""card-header bg-primary border-bottom"">
                            <div class=""row text-white"">
                                <div class=""col-2"">
                                    <h6 class=""mt-1"">");
#nullable restore
#line 68 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                Write(m.timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                </div>\r\n                                <div class=\"col-10\">\r\n                                    <h5>");
#nullable restore
#line 71 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                   Write(m.subject);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                        </div>
                        <div class=""card-body"">
                            <div class=""row"">
                                <h6 class=""text-info"">From: </h6>
                                <p id=""sender"" class=""card-title mb-1 ml-2"">");
#nullable restore
#line 78 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                       Write(m.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                <h6 class=\"text-info\">Message: </h6>\r\n                                <p id=\"msg\" class=\"card-text mb-1 ml-2\">");
#nullable restore
#line 82 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                   Write(m.messageContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2780cc5b20697791eebc3d83552d60f687fc38ae10496", async() => {
                WriteLiteral("\r\n                                <input type=\"hidden\" name=\"messageId\"");
                BeginWriteAttribute("value", " value=\"", 3398, "\"", 3411, 1);
#nullable restore
#line 85 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
WriteAttributeValue("", 3406, m.ID, 3406, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                                <div class=""form-group"">
                                    <textarea class=""form-control"" name=""answer"" placeholder=""Write your answer here..."" required></textarea>
                                </div>
                                <div class=""form-group"">
                                    <button class=""btn btn-info"" type=""submit"">Answer</button>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 95 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h5 class=\"text-info\">There are no Unanswered Messages</h5>\r\n                <hr />\r\n");
#nullable restore
#line 101 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
             if (answered.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4 class=\"text-info\">Answered</h4>\r\n");
#nullable restore
#line 106 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                 foreach (var m in answered)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""card mb-3"">
                        <div class=""card-header bg-primary border-bottom"">
                            <div class=""row text-white"">
                                <div class=""col-2"">
                                    <h6 class=""mt-1"">");
#nullable restore
#line 112 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                Write(m.timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                </div>\r\n                                <div class=\"col-10\">\r\n                                    <h5>");
#nullable restore
#line 115 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                   Write(m.subject);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                        </div>
                        <div class=""card-body"">
                            <div class=""row"">
                                <h6 class=""text-info"">From:</h6>
                                <p id=""sender"" class=""card-title mb-1 ml-2"">");
#nullable restore
#line 122 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                       Write(m.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                <h6 class=\"text-info\">Message: </h6>\r\n                                <p id=\"msg\" class=\"card-text mb-1 ml-2\">");
#nullable restore
#line 126 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                   Write(m.messageContent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                            <hr />
                            <div class=""row"">
                                <h6 class=""text-info"">Answer:</h6>
                                <p id=""a s"" class=""card-text mb-1 ml-2"">");
#nullable restore
#line 131 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                   Write(m.answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 136 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                 

            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <hr />\r\n                <h4 class=\"text-info\">There are no Answered Messages</h4>\r\n");
#nullable restore
#line 143 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 143 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h4 class=\"text-info\">There are no Internal Messages</h4>\r\n");
#nullable restore
#line 148 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>



<!--EXTERNAL-->
<div id=""external"" style=""display:none"">
    <div class=""row no-gutters mt-2"">
        <div class=""col-3"">
            <h3 class=""text-secondary"">External messages</h3>
        </div>
        <div class=""col-2"">
            <button class=""btn btn-info float-left"" type=""button"" onclick=""toggle('external','internal')"">Show Internal Messages</button>
        </div>
    </div>
    <hr />

");
#nullable restore
#line 168 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
      
        var ext = Model.FindAll(m => m.type.Trim() == "external");
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 170 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
         if (ext.Count > 0)
        {
            var unanswered = ext.FindAll(m => m.answer == null);
            var answered = ext.FindAll(m => m.answer != null);
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 174 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
             if (unanswered.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4 class=\"text-info\">Unanswered</h4>\r\n");
#nullable restore
#line 177 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                foreach (var m in unanswered)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""card mb-3"">
                        <div class=""card-header bg-primary border-bottom"">
                            <div class=""row text-white"">
                                <div class=""col-2"">
                                    <h6 class=""mt-1"">");
#nullable restore
#line 183 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                Write(m.timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                </div>\r\n                                <div class=\"col-10\">\r\n                                    <h5>");
#nullable restore
#line 186 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                   Write(m.subject);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                        </div>
                        <div class=""card-body"">
                            <div class=""row"">
                                <h6 class=""text-info"">From: </h6>
                                <p id=""sender"" class=""card-title mb-1 ml-2"">");
#nullable restore
#line 193 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                       Write(m.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                <h6 class=\"text-info\">Message: </h6>\r\n                                <p id=\"msg\" class=\"card-text mb-1 ml-2\">");
#nullable restore
#line 197 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                   Write(m.messageContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2780cc5b20697791eebc3d83552d60f687fc38ae22262", async() => {
                WriteLiteral("\r\n                                <input type=\"hidden\" name=\"messageId\"");
                BeginWriteAttribute("value", " value=\"", 8174, "\"", 8187, 1);
#nullable restore
#line 200 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
WriteAttributeValue("", 8182, m.ID, 8182, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                                <div class=""form-group"">
                                    <textarea class=""form-control"" name=""answer"" placeholder=""Write your answer here..."" required></textarea>
                                </div>
                                <div class=""form-group"">
                                    <button class=""btn btn-info"" type=""submit"">Answer</button>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 211 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4 class=\"text-info\">There are no Unanswered Messages</h4>\r\n                <hr />\r\n");
#nullable restore
#line 217 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 219 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
             if (answered.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4 class=\"text-info\">Answered</h4>\r\n");
#nullable restore
#line 222 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                 foreach (var m in answered)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""card mb-3"">
                        <div class=""card-header bg-primary border-bottom"">
                            <div class=""row text-white"">
                                <div class=""col-2"">
                                    <h6 class=""mt-1"">");
#nullable restore
#line 228 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                Write(m.timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                </div>\r\n                                <div class=\"col-10\">\r\n                                    <h5>");
#nullable restore
#line 231 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                   Write(m.subject);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                        </div>
                        <div class=""card-body"">
                            <div class=""row"">
                                <h6 class=""text-info"">From: </h6>
                                <p id=""sender"" class=""card-title mb-1 ml-2""><strong>");
#nullable restore
#line 238 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                               Write(m.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                <h6 class=\"text-info\">Message: </h6>\r\n                                <p id=\"msg\" class=\"card-text mb-1 ml-2\">");
#nullable restore
#line 242 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                   Write(m.messageContent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                            <hr />
                            <div class=""row"">
                                <h6 class=""text-info"">Answer: </h6>
                                <p id=""a s"" class=""card-text mb-1 ml-2"">");
#nullable restore
#line 247 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                                                                   Write(m.answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 251 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 251 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
                 

            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <hr />\r\n                <h4 class=\"text-info\">There are no Answered Messages</h4>\r\n");
#nullable restore
#line 258 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 258 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h4 class=\"text-info\">There are no External Messages</h4>\r\n");
#nullable restore
#line 263 "D:\VSprojects\VisualStudioProj\Thesis\VirusTracker\Views\Admin\Messages.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Message>> Html { get; private set; }
    }
}
#pragma warning restore 1591
