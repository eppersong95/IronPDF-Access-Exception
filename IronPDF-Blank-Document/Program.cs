using IronPdf;
using System.Drawing;

var baseDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
var fileIdentifier = DateTime.UtcNow.Ticks;

//get license key from email
IronPdf.License.LicenseKey = "";
IronPdf.Logging.Logger.EnableDebugging = true;
IronPdf.Logging.Logger.LogFilePath = $"{baseDirectory}\\Logs\\Logs-{fileIdentifier}.txt";
IronPdf.Logging.Logger.LoggingMode = IronPdf.Logging.Logger.LoggingModes.All;


var pathToPdf = $"{baseDirectory}\\Access-Exception.pdf";
var pdfBytes = File.ReadAllBytes(pathToPdf);
var pdfDocument = ConvertPdf(pdfBytes);

var outputPath = $"{baseDirectory}\\Output\\Access-Exception-{fileIdentifier}.pdf";
File.WriteAllBytes(outputPath, pdfDocument.BinaryData);

static PdfDocument ConvertPdf(byte[] pdfBytes)
{
    var pdf = new PdfDocument(pdfBytes);
    var pdfList = new List<PdfDocument>();

    var pageNumber = 0;
    while (pageNumber < pdf.PageCount)
    {
        //exception here
        var bitmapPage = pdf.PageToBitmap(pageNumber);

        var imageToAdd = bitmapPage as Image;

        var convertedPdf = ImageToPdfConverter.ImageToPdf(imageToAdd, IronPdf.Imaging.ImageBehavior.FitToPageAndMaintainAspectRatio);
        pdfList.Add(convertedPdf);

        pageNumber++;
    }

    return PdfDocument.Merge(pdfList);
}