#pragma checksum "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Meal\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07501807a62c3925c86157bf7bf82416da87921d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meal_List), @"mvc.1.0.view", @"/Views/Meal/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Meal/List.cshtml", typeof(AspNetCore.Views_Meal_List))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07501807a62c3925c86157bf7bf82416da87921d", @"/Views/Meal/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b3a2c7b082ef7b728d32ecba649e644f5c54967", @"/Views/_ViewImports.cshtml")]
    public class Views_Meal_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MealsListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Meal\List.cshtml"
 foreach (var p in Model.Meals) {
    

#line default
#line hidden
            BeginContext(66, 33, false);
#line 4 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Meal\List.cshtml"
Write(Html.Partial("ProductSummary", p));

#line default
#line hidden
            EndContext();
#line 4 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Meal\List.cshtml"
                                      
}

#line default
#line hidden
            BeginContext(102, 5, true);
            WriteLiteral("\n<div");
            EndContext();
            BeginWriteAttribute("page-model", " page-model=\"", 107, "\"", 137, 1);
#line 7 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Meal\List.cshtml"
WriteAttributeValue("", 120, Model.PagingInfo, 120, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(138, 142, true);
            WriteLiteral(" page-action=\"List\" page-classes-enabled=\"true\"\n     page-class=\"btn\" page-class-normal=\"btn-secondary\"\n     page-class-selected=\"btn-primary\"");
            EndContext();
            BeginWriteAttribute("page-url-category", " page-url-category=\"", 280, "\"", 322, 1);
#line 9 "C:\Users\Laerositus\Dropbox\Avans\Jaar 2\SSWF\EasyMealApplication\EasyMealOrderGUI\Views\Meal\List.cshtml"
WriteAttributeValue("", 300, Model.CurrentCategory, 300, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(323, 47, true);
            WriteLiteral("\n     class=\"btn-group pull-right m-1\">\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MealsListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
