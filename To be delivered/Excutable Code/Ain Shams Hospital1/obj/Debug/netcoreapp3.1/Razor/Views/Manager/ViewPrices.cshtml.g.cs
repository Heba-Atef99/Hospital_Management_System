#pragma checksum "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Manager\ViewPrices.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32f30e527450b4ecfb9ceda7e83a76e60df967cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_ViewPrices), @"mvc.1.0.view", @"/Views/Manager/ViewPrices.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32f30e527450b4ecfb9ceda7e83a76e60df967cf", @"/Views/Manager/ViewPrices.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23c69ec494828cf325b64c7c4bec3df379c1a229", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_ViewPrices : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Manager\ViewPrices.cshtml"
  
    Layout = "~/Views/Manager_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<a class=""btn btn-info btn-lg btn-block"" href=""/Manager/AddPrice"" role=""button"">Add Service</a>
<a class=""btn btn-secondary btn-lg btn-block"" href=""/Manager/ManagerEdit"" role=""button"">Edit Prices</a>
<a class=""btn btn-info btn-lg btn-block"" href=""/Manager/Deleteprice"" role=""button"">Delete Service</a>

<br/>
<table class=""table table-bordered table-hover"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">Name</th>
            <th scope=""col"">Price</th>

        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Manager\ViewPrices.cshtml"
         foreach (var x in ViewBag.C1)

        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 24 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Manager\ViewPrices.cshtml"
                           Write(x.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 25 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Manager\ViewPrices.cshtml"
               Write(x.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 28 "E:\Software Project\Hospital\To be delivered\Excutable Code\Ain Shams Hospital1\Views\Manager\ViewPrices.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n</table>\r\n<br />\r\n\r\n\r\n\r\n");
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
