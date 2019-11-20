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
    public static class DocumentFactory
    {
        /// <summary>
        ///     Creates a blank <see cref="WordprocessingDocument"/> for a course template.
        /// </summary>
        /// <param name="documentStream">
        ///     The stream that the document should be written to.
        /// </param>
        /// <returns>
        ///     A new editable <see cref="WordprocessingDocument"/> wrapping the new document on the stream.
        /// </returns>
        public static WordprocessingDocument Create(Stream documentStream, string author = null)
        {
            return OpenXmlHelpers.CreateFromTemplate(
                @"J:\À conserver\Session A2019\Projet\PlanC\src\PlanC.DocumentGeneration\CourseTemplate\DocumentTemplate.dotx", documentStream, author);
        }
    }
}
