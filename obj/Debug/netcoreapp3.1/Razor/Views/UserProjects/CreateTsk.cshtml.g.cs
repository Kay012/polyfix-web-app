#pragma checksum "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b291d2bbcaf751d5f5140a8b48e2309984948693"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserProjects_CreateTsk), @"mvc.1.0.view", @"/Views/UserProjects/CreateTsk.cshtml")]
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
#line 1 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\_ViewImports.cshtml"
using Mvc.RoleAuthorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\_ViewImports.cshtml"
using Mvc.RoleAuthorization.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b291d2bbcaf751d5f5140a8b48e2309984948693", @"/Views/UserProjects/CreateTsk.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16a9792185f088e1699adb291f3e531d9b921d83", @"/Views/_ViewImports.cshtml")]
    public class Views_UserProjects_CreateTsk : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Poly.Models.UserTask>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdatedTsks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IndexTsk", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateTsks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
  
    ViewData["Title"] = "CreateTsk";
    Layout = "~/Views/Shared/_Layout.cshtml";



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 13 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
Write(ViewBag.Tsks.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<p>Select users for this Task</p>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b291d2bbcaf751d5f5140a8b48e23099849486936686", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b291d2bbcaf751d5f5140a8b48e23099849486936956", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 20 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\">Task Id</label>\r\n");
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b291d2bbcaf751d5f5140a8b48e23099849486938805", async() => {
                    WriteLiteral("\r\n                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b291d2bbcaf751d5f5140a8b48e23099849486939093", async() => {
#nullable restore
#line 27 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                                                   Write(ViewBag.Tsks.TskId);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                       WriteLiteral(ViewBag.Tsks.TskId);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 26 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TskId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n\r\n");
                WriteLiteral("\r\n\r\n\r\n\r\n            <style>\r\n\r\n                th, td {\r\n                    padding: 7px;\r\n                    background-color: none;\r\n                }\r\n            </style>\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 51 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
             if (ViewBag.NotAddedUsersCOUNT != 0)
            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                <p><h4 style=\" color: blue;\">Un-Assigned users (check to add)</h4></p>\r\n");
                WriteLiteral("                <table>\r\n\r\n\r\n");
#nullable restore
#line 59 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                     foreach (var item in ViewBag.NotAddedUsers)
                    {


#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                <input type=\"checkbox\" name=\"UserIds\"");
                BeginWriteAttribute("value", " value=\"", 1674, "\"", 1690, 1);
#nullable restore
#line 64 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
WriteAttributeValue("", 1682, item.Id, 1682, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            </td>\r\n\r\n\r\n\r\n                            <td>\r\n                                <label> ");
#nullable restore
#line 70 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                                   Write(item.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 70 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                                                   Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 70 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                                                                   Write(item.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                            </td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 74 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </table>\r\n");
#nullable restore
#line 77 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 80 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
             if (ViewBag.selectedUsersCOUNT != 0)
            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                <p><h4 style=\" color: red;\">Assigned users (check to remove)</h4></p>\r\n");
                WriteLiteral("                <table>\r\n\r\n\r\n");
#nullable restore
#line 88 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                     foreach (var item in ViewBag.selectedUsers)
                    {


#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                <input type=\"checkbox\" name=\"UserIDELS\"");
                BeginWriteAttribute("value", " value=\"", 2418, "\"", 2434, 1);
#nullable restore
#line 93 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
WriteAttributeValue("", 2426, item.Id, 2426, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            </td>\r\n");
                WriteLiteral("\r\n\r\n                            <td>\r\n                                <label> ");
#nullable restore
#line 102 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                                   Write(item.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 102 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                                                   Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 102 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                                                                   Write(item.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                            </td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 106 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </table>\r\n");
#nullable restore
#line 109 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Create New list\" class=\"btn btn-primary\" />\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b291d2bbcaf751d5f5140a8b48e230998494869318709", async() => {
                    WriteLiteral("Update Selected Employees");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n            <div>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b291d2bbcaf751d5f5140a8b48e230998494869320115", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 123 "C:\Users\hp\3D Objects\polyapp (2) (1)\polyapp (1)\PolyFix\Views\UserProjects\CreateTsk.cshtml"
                                           WriteLiteral(ViewBag.Tsks.TskId);

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
                WriteLiteral("\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n   \r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Poly.Models.UserTask> Html { get; private set; }
    }
}
#pragma warning restore 1591
