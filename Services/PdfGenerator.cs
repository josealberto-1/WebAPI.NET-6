using DinkToPdf;
using DinkToPdf.Contracts;
using iText.Layout.Renderer;

namespace WebApiPlantillas.Services
{
    public class PdfGenerator
    {
        private readonly IConverter _converter;

        public PdfGenerator(IConverter converter)
        {
            this._converter = converter;
        }

        public byte[] GeneratorPdf(string HtmlContent)
        {
            var globalsettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 },
                DocumentTitle = "Generated PDF"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = HtmlContent,
                //page = _HostingEnviroment.ContentRootPath + "\\htmlpagenew.html",
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 12, Right = "page {page} of {topage}", Line = true, Spacing = 2.812 },
                FooterSettings = { FontSize = 12, Line = true, Right = "© " + DateTime.Now.Year }

            };

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = globalsettings,
                Objects = { objectSettings }
            };
           return _converter.Convert(document);
        }
    }
}
