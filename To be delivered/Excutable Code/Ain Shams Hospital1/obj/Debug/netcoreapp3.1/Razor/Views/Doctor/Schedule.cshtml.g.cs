#pragma checksum "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Doctor\Schedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d1765322ee6177c96540167087a19d376863fdf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_Schedule), @"mvc.1.0.view", @"/Views/Doctor/Schedule.cshtml")]
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
#line 1 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d1765322ee6177c96540167087a19d376863fdf", @"/Views/Doctor/Schedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23c69ec494828cf325b64c7c4bec3df379c1a229", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_Schedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Doctor\Schedule.cshtml"
  
    //ViewData["Title"] = "Schedule";
    var schedule = ViewBag.schedule;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>My schedule</h1>
<div class="" container-fluid text-center col-md-6 "">
    <table class=""table table-bordered table-striped"">
        <thead>
        <tr>
            <td> <b>Date</b></td>
            <td> <b>Follow Up </b></td>
        </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Doctor\Schedule.cshtml"
             foreach (var n in schedule)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td> ");
#nullable restore
#line 20 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Doctor\Schedule.cshtml"
                    Write(n.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td> ");
#nullable restore
#line 21 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Doctor\Schedule.cshtml"
                    Write(n.Follow_Up_Type.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 23 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Doctor\Schedule.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    \r\n</div>\r\n<style>\r\n    .table{\r\n        background-color:white\r\n    }\r\n</style>\r\n");
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
