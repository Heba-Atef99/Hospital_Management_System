#pragma checksum "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6aa68ba8bf5bcc888b36f7d7f4944e93b881094"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_UserProfile), @"mvc.1.0.view", @"/Views/Profile/UserProfile.cshtml")]
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
#line 1 "D:\software project\gitHub\Ain Shams Hospital\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\software project\gitHub\Ain Shams Hospital\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\software project\gitHub\Ain Shams Hospital\Views\_ViewImports.cshtml"
using Ain_Shams_Hospital.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6aa68ba8bf5bcc888b36f7d7f4944e93b881094", @"/Views/Profile/UserProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23c69ec494828cf325b64c7c4bec3df379c1a229", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_UserProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ain_Shams_Hospital.Data.Entities.Patient>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
  
    ViewData["Title"] = "UserProfile";
    Layout = "_PatientLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\"color:#ff0000\">My Profile</h1>\r\n\r\n<div>\r\n    \r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\" style=\"color:#0917b7;font-size:20px;font-weight:bold\">\r\n            ");
#nullable restore
#line 15 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n           : ");
#nullable restore
#line 18 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
        Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\" style=\"color:#0917b7;font-size:20px;font-weight:bold\">\r\n            ");
#nullable restore
#line 21 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </dt>\r\n        <dd class=\"col-sm-10\" >\r\n           : ");
#nullable restore
#line 24 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
        Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\" style=\"color:#0917b7;font-size:20px;font-weight:bold\">\r\n            ");
#nullable restore
#line 27 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.Health_Progress));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n           : ");
#nullable restore
#line 30 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
        Write(Html.DisplayFor(model => model.Health_Progress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\"style=\"color:#0917b7;font-size:20px;font-weight:bold\">\r\n            ");
#nullable restore
#line 33 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
       Write(Html.DisplayNameFor(model => model.Medical_Record));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n           : ");
#nullable restore
#line 36 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
        Write(Html.DisplayFor(model => model.Medical_Record));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 41 "D:\software project\gitHub\Ain Shams Hospital\Views\Profile\UserProfile.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |  <a href=\"/Patient/Home\">Back to List</a> \r\n    \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ain_Shams_Hospital.Data.Entities.Patient> Html { get; private set; }
    }
}
#pragma warning restore 1591
