#pragma checksum "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af37a8a0fe56227d46d15f0aaa7c4e7489b9cf10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patron_PrintTicket2), @"mvc.1.0.view", @"/Views/Patron/PrintTicket2.cshtml")]
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
#line 1 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\_ViewImports.cshtml"
using Ticketr;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\_ViewImports.cshtml"
using Ticketr.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af37a8a0fe56227d46d15f0aaa7c4e7489b9cf10", @"/Views/Patron/PrintTicket2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5092de8f75ae74b9d370b5daf9395c8e613dce68", @"/Views/_ViewImports.cshtml")]
    public class Views_Patron_PrintTicket2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SeriesSeatPatronRel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewAll", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Event", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewAllSeries", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Series", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewAllPatrons", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Patron", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af37a8a0fe56227d46d15f0aaa7c4e7489b9cf106149", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Document</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af37a8a0fe56227d46d15f0aaa7c4e7489b9cf107325", async() => {
                WriteLiteral("\r\n    <div class=\"BackgroundWrapper\">\r\n        <div class=\"InnerWrapper\">\r\n            <p>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af37a8a0fe56227d46d15f0aaa7c4e7489b9cf107679", async() => {
                    WriteLiteral("Dashboard");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" | ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af37a8a0fe56227d46d15f0aaa7c4e7489b9cf109114", async() => {
                    WriteLiteral("View all events");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" | ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af37a8a0fe56227d46d15f0aaa7c4e7489b9cf1010555", async() => {
                    WriteLiteral("View all Series");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" | ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af37a8a0fe56227d46d15f0aaa7c4e7489b9cf1011997", async() => {
                    WriteLiteral("View all Patrons");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" </p>\r\n            <h1>Ticket for ");
#nullable restore
#line 14 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                      Write(ViewBag.curPatron.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 14 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                                   Write(ViewBag.curPatron.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n            <p></p>\r\n");
#nullable restore
#line 16 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <br>\r\n                <div class=\"mainTicket\"");
                BeginWriteAttribute("style", " style=\"", 894, "\"", 945, 4);
                WriteAttributeValue("", 902, "background-image:", 902, 17, true);
                WriteAttributeValue(" ", 919, "url(", 920, 5, true);
#nullable restore
#line 19 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
WriteAttributeValue("", 924, ViewBag.TicketImage, 924, 20, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 944, ")", 944, 1, true);
                EndWriteAttribute();
                WriteLiteral(@">
                    <div class=""leftTicket"">
                        <h6 style=""text-align:center;"">CodingDojo Productions</h6>
                        <p style=""text-align:center;"">presents</p>
                        <h3 style=""text-align:center;"">");
#nullable restore
#line 23 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                                  Write(item.Series.Event.EventName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                        <h6 style=\"text-align:center;\">");
#nullable restore
#line 24 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                                  Write(item.Series.CombinedTime.ToString("ddd, MMM dd, yyyy @ hh:mm tt"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n                        <h6 style=\"text-align:center;\">");
#nullable restore
#line 25 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                                  Write(item.Series.SeriesVenue);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n                        <br>\r\n");
                WriteLiteral("                        <h3 style=\"display: inline-block; width: 280px;\">Seat Number: ");
#nullable restore
#line 29 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                                                                 Write(item.Seat.SeatNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n");
                WriteLiteral("                        <h3 style=\"display: inline-block; text-align:right; width: 280px\" >$");
#nullable restore
#line 31 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                                                                       Write(Math.Round(item.Series.TicketPrice,2));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h3>
                    </div>
                    <div class=""rightTicket"">
                        <p class=""stubText"">|| || ||||| || | | | || ||| | || || ||||| || | | | || ||| |</p>                    
                    </div>
                    <div class=""rightTicket"">
                        <p class=""stubText"">");
#nullable restore
#line 37 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                       Write(item.SeriesSeatPatronId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>                    \r\n                    </div>\r\n                    <div class=\"rightTicket\">\r\n                        <p class=\"stubText\">");
#nullable restore
#line 40 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                       Write(item.Series.CombinedTime.ToString("ddd, MMM dd, yyyy @ hh:mm tt"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>                    \r\n                    </div>\r\n                    <div class=\"rightTicket\">\r\n                        <p class=\"stubText\">Seat Number: ");
#nullable restore
#line 43 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
                                                    Write(item.Seat.SeatNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>                    \r\n                    </div>\r\n                </div>\r\n                <br>\r\n");
#nullable restore
#line 47 "C:\Users\User\Desktop\Dojo_Assignments\Projects\Ticketing Service\Ticketr\Views\Patron\PrintTicket2.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SeriesSeatPatronRel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
