#pragma checksum "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b05993022754aa5f3a0936f086f3c52511dce0ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_finance_stateview1), @"mvc.1.0.view", @"/Views/finance/stateview1.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b05993022754aa5f3a0936f086f3c52511dce0ad", @"/Views/finance/stateview1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23c69ec494828cf325b64c7c4bec3df379c1a229", @"/Views/_ViewImports.cshtml")]
    public class Views_finance_stateview1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml"
  
    Layout = "~/Views/Finance_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-bordered table-hover"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">Service</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Money</th>
            <th scope=""col"">Date</th>

        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml"
         foreach (var x in ViewBag.List1)

        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 25 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml"
                           Write(x.Follow_Up_Type.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n\r\n\r\n                <td>");
#nullable restore
#line 29 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml"
               Write(x.Patient.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml"
               Write(x.Money);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml"
               Write(x.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <tr>\r\n            <td>Total = ");
#nullable restore
#line 36 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\finance\stateview1.cshtml"
                   Write(ViewBag.t);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </tbody>\r\n\r\n</table>");
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
