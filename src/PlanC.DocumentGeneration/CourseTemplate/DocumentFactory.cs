using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    public class DocumentFactory
    {
        /// <summary>
        ///     Creates a blank <see cref="WordprocessingDocument"/> for a course template.
        /// </summary>
        /// <param name="documentStream">
        ///     The stream that the document should be written to.
        /// </param>
        /// <param name="isEditable">
        ///     Whether or not the returned document is editable or read-only.
        /// </param>
        /// <param name="settings"></param>
        /// <returns>
        ///     A new <see cref="WordprocessingDocument"/> wrapping the new document on the stream.
        /// </returns>
        public static WordprocessingDocument Create(Stream documentStream, bool isEditable = true)
        {
            Contract.Requires(documentStream != null);
            
            WordprocessingDocument document = null;
            using (var template = WordprocessingDocument.Open(@"J:\À conserver\Session A2019\Projet\PlanC\src\PlanC.DocumentGeneration\CourseTemplate\DocumentTemplate.dotx", false))
            {
                //Creates a copy of the template
                document = (WordprocessingDocument)template.Clone(documentStream, isEditable);
            }

            //Transform the template into a document.
            document.ChangeDocumentType(WordprocessingDocumentType.Document);

            document.PackageProperties.Created = DateTime.Now;
            document.PackageProperties.Creator = "Moi";
            document.PackageProperties.Revision = null;

            return document;
        }
    }
}
