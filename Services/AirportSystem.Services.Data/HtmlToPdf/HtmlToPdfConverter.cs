namespace AirportSystem.Services.Data.HtmlToPdf
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using OpenCvSharp;

    public interface IHtmlToPdfConverter
    {
        //byte[] Convert(string basePath, string htmlCode, FormatType formatType, OrientationType orientationType);
    }

    public class HtmlToPdfConverter : IHtmlToPdfConverter
    {
        //public byte[] Convert(string basePath, string htmlCode, FormatType formatType = FormatType.A4, OrientationType orientationType = OrientationType.Portrait)
        //{
        //    var inputFileName = $"input_{Guid.NewGuid()}.html";
        //    var outputFileName = $"output_{Guid.NewGuid()}.pdf";
        //    File.WriteAllText($"{basePath}/{inputFileName}", htmlCode);
        //    var startInfo = new ProcessStartInfo("phantomjs.exe")
        //    {
        //        WorkingDirectory = basePath,
        //        Arguments = $"rasterize.js \"{inputFileName}\" \"{outputFileName}\" \"{formatType}\" \"{orientationType.ToString().ToLower()}\"",
        //        UseShellExecute = true,
        //    };

        //    var process = new Process { StartInfo = startInfo };
        //    process.Start();

        //    process.WaitForExit();

        //    var bytes = File.ReadAllBytes($"{basePath}/{outputFileName}");

        //    File.Delete($"{basePath}/{inputFileName}");
        //    File.Delete($"{basePath}/{outputFileName}");

        //    return bytes;
        //}
    }
}
