#pragma checksum "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d96ae3b9f49c6f049f167aede6216b3516a66356"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Index.cshtml", typeof(AspNetCore.Views_Admin_Index))]
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
#line 1 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\_ViewImports.cshtml"
using EasyMealOrderGUI.Models;

#line default
#line hidden
#line 2 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\_ViewImports.cshtml"
using EasyMealOrderGUI.Models.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\_ViewImports.cshtml"
using EasyMealOrderGUI.Infrastructure;

#line default
#line hidden
#line 4 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\_ViewImports.cshtml"
using EasyMealCore.DomainModel;

#line default
#line hidden
#line 5 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\_ViewImports.cshtml"
using EasyMealCore.DomainServices;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d96ae3b9f49c6f049f167aede6216b3516a66356", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b3a2c7b082ef7b728d32ecba649e644f5c54967", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Meal>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SeedDatabase", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(25, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
  
    ViewBag.Title = "All Meals";
    Layout = "_AdminLayout";

#line default
#line hidden
            BeginContext(93, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 8 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
 if (Model.Count() == 0) {


#line default
#line hidden
            BeginContext(122, 42, true);
            WriteLiteral("    <div class=\"text-center m-2\">\n        ");
            EndContext();
            BeginContext(164, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96ae3b9f49c6f049f167aede6216b3516a663567002", async() => {
                BeginContext(210, 89, true);
                WriteLiteral("\n            <button type=\"submit\" class=\"btn btn-danger\">Seed Database</button>\n        ");
                EndContext();
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
            EndContext();
            BeginContext(306, 12, true);
            WriteLiteral("\n    </div>\n");
            EndContext();
#line 15 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"

} else {


#line default
#line hidden
            BeginContext(329, 255, true);
            WriteLiteral("    <table class=\"table table-striped table-bordered table-sm\">\n        <tr>\n            <th class=\"text-right\">ID</th>\n            <th>Name</th>\n            <th class=\"text-right\">Price</th>\n            <th class=\"text-center\">Actions</th>\n        </tr>\n");
            EndContext();
#line 25 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
         foreach (var item in Model) {

#line default
#line hidden
            BeginContext(623, 56, true);
            WriteLiteral("            <tr>\n                <td class=\"text-right\">");
            EndContext();
            BeginContext(680, 11, false);
#line 27 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
                                  Write(item.MealID);

#line default
#line hidden
            EndContext();
            BeginContext(691, 26, true);
            WriteLiteral("</td>\n                <td>");
            EndContext();
            BeginContext(718, 9, false);
#line 28 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
               Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(727, 45, true);
            WriteLiteral("</td>\n                <td class=\"text-right\">");
            EndContext();
            BeginContext(773, 24, false);
#line 29 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
                                  Write(item.Price.ToString("c"));

#line default
#line hidden
            EndContext();
            BeginContext(797, 67, true);
            WriteLiteral("</td>\n                <td class=\"text-center\">\n                    ");
            EndContext();
            BeginContext(864, 495, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96ae3b9f49c6f049f167aede6216b3516a6635611098", async() => {
                BeginContext(904, 25, true);
                WriteLiteral("\n                        ");
                EndContext();
                BeginContext(929, 173, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96ae3b9f49c6f049f167aede6216b3516a6635611504", async() => {
                    BeginContext(1040, 58, true);
                    WriteLiteral("\n                            Edit\n                        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-mealId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 33 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
                                 WriteLiteral(item.MealID);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["mealId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-mealId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["mealId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1102, 59, true);
                WriteLiteral("\n                        <input type=\"hidden\" name=\"MealID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1161, "\"", 1181, 1);
#line 36 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1169, item.MealID, 1169, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1182, 170, true);
                WriteLiteral(" />\n                        <button type=\"submit\" class=\"btn btn-danger btn-sm\">\n                            Delete\n                        </button>\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1359, 41, true);
            WriteLiteral("\n                </td>\n            </tr>\n");
            EndContext();
#line 43 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1410, 13, true);
            WriteLiteral("    </table>\n");
            EndContext();
#line 45 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Admin\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1425, 31, true);
            WriteLiteral("\n<div class=\"text-center\">\n    ");
            EndContext();
            BeginContext(1456, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d96ae3b9f49c6f049f167aede6216b3516a6635616893", async() => {
                BeginContext(1503, 11, true);
                WriteLiteral("Add Product");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1518, 8, true);
            WriteLiteral("\n</div>\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Meal>> Html { get; private set; }
    }
}
#pragma warning restore 1591
