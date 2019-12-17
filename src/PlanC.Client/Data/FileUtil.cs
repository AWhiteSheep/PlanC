using Microsoft.JSInterop;
using Syncfusion.EJ;
using Syncfusion.EJ.Export;
using Syncfusion.Compression;
using Syncfusion.DocIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.DocIO.DLS;
using System.IO;

namespace PlanC.Client.Data
{
    public static class FileUtil
    {
        /// <summary>
        /// File upload avec js runtime
        /// </summary>
        /// <param name="js"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));

        // return une demande invke avec jsRuntime pour téléchargé du côté client

        public static WordDocument GetDocument(string htmlText)
        {
            // renvoit du word qui était en fait du html
            WordDocument document = null;
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Default);
            htmlText = htmlText.Replace("\"", "'");
            XmlConversion XmlText = new XmlConversion(htmlText);
            XhtmlConversion XhtmlText = new XhtmlConversion(XmlText);
            writer.Write(XhtmlText.ToString());
            writer.Flush();
            stream.Position = 0;
            document = new WordDocument(stream, FormatType.Html, XHTMLValidationType.None);
            return document;
        }
    }
}
