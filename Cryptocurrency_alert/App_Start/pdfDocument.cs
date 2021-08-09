using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IronPdf;
using System.IO;

namespace Cryptocurrency_alert.App_Start
{
    public class pdfDocument
    {
        public pdfDocument()
        {
            var htmlToPdf = new HtmlToPdf();
            var html = @"<h1>Hello World!</h1><br><p>This is IronPdf...-</p>";
            var pdf = htmlToPdf.RenderHtmlAsPdf(html);
      
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "cryptocurrency.pdf"));
        }
    }
}
