#pragma checksum "E:\Software Project\My Local Project\Ain Shams University\Views\Home\saveDonation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5138c5ec2985ababa6702685469251fb0f73bffb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_saveDonation), @"mvc.1.0.view", @"/Views/Home/saveDonation.cshtml")]
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
#line 1 "E:\Software Project\My Local Project\Ain Shams University\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Software Project\My Local Project\Ain Shams University\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Software Project\My Local Project\Ain Shams University\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5138c5ec2985ababa6702685469251fb0f73bffb", @"/Views/Home/saveDonation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23c69ec494828cf325b64c7c4bec3df379c1a229", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_saveDonation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ain_Shams_University.ViewModels.DonationsVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Software Project\My Local Project\Ain Shams University\Views\Home\saveDonation.cshtml"
  
    ViewData["Title"] = "saveDonation";


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <h1>Thanks for Supporting ! ");
#nullable restore
#line 7 "E:\Software Project\My Local Project\Ain Shams University\Views\Home\saveDonation.cshtml"
                           Write(ViewBag.visitorname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ain_Shams_University.ViewModels.DonationsVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
