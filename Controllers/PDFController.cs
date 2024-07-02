using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPlantillas.Services;

namespace WebApiPlantillas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly PdfGenerator _pdfGenerator;
        public PDFController(PdfGenerator pdfGenerator)
        {
            this._pdfGenerator = pdfGenerator;
        }

        [HttpPost]
        public IActionResult GeneratePdf()
        {
            string htmlContent = "<html>\r\n<head>\r\n<title>Carta de Solicitud</title>\r\n</head>\r\n<body>\r\n<h1>Carta de Solicitud</h1>\r\n<p>Estimado/a [Nombre del Destinatario],</p>\r\n<p>Me dirijo a usted para expresar mi interés en el puesto de [Puesto Deseado]\r\nen su empresa. Soy un/a profesional con experiencia en el campo y estoy\r\nentusiasmado/a con la oportunidad de formar parte de su equipo.</p>\r\nHabilidades:\r\n<ul>\r\n<li>Habilidad No.1</li>\r\n<li>Mi super habilidad 2</li>\r\n<li>Otra habiliad que tengo</li>\r\n</ul>\r\n<p>Adjunto a esta carta encontrará mi currículum vitae, que detalla mi formación\r\nacadémica y mi experiencia laboral relevante. Estoy seguro/a de que mis\r\nhabilidades y conocimientos en [Áreas Relevantes] serán un valioso aporte para su\r\norganización.</p>\r\n<p>Quedo a su disposición para proporcionar cualquier información adicional que\r\npueda necesitar. Agradezco de antemano su consideración y espero tener la\r\noportunidad de discutir cómo puedo contribuir al éxito de su empresa.</p>\r\n<p>Atentamente,</p>\r\n<p>[Tu Nombre]</p>\r\n<p>[Fecha Actual]</p>\r\n</body>\r\n</html>";


            byte[] pdfBytes = _pdfGenerator.GeneratorPdf(htmlContent);

            return File(pdfBytes, "aplication/pdf", "generated.pdf");
        }
    }
}
