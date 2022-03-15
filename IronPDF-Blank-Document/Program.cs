using IronPdf;

var baseDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
var fileIdentifier = DateTime.UtcNow.Ticks;

IronPdf.License.LicenseKey = "IRONPDF.PRIORITYONE.IRO191217.6051.28135-B95DEFC8E0-JRGJIQRLFCRCS-TGCHNC6V3HCM-MUYXYHO2SCTP-OMFCKRCZKZIF-OFHVP4JNFCYS-K42PHR-LAAAAAAAATCLEA-UPGRADE-ESQT6I.RENEW.SUPPORT.17.DEC.2023";
IronPdf.Logging.Logger.EnableDebugging = true;
IronPdf.Logging.Logger.LogFilePath = $"{baseDirectory}\\Logs\\Logs-{fileIdentifier}.txt";
IronPdf.Logging.Logger.LoggingMode = IronPdf.Logging.Logger.LoggingModes.All;


var pathToPdf = $"{baseDirectory}\\BuggyPdf.pdf";
var pdfBytes = File.ReadAllBytes(pathToPdf);
var pdfDocument = new PdfDocument(pdfBytes);

var outputPath = $"{baseDirectory}\\Output\\Blank-Pdf-{fileIdentifier}.pdf";
File.WriteAllBytes(outputPath, pdfDocument.BinaryData);