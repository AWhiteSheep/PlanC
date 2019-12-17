using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;

namespace PlanC.DocumentGeneration
{
    internal static class OpenXmlHelpers
    {
        public static MainDocumentPart GetOrAddMainDocumentPart(this WordprocessingDocument document)
        {
            return document.MainDocumentPart ?? document.AddMainDocumentPart();
        }

        public static CustomXmlPart GetOrAddCustomXmlPart(this MainDocumentPart mainDocumentPart, string id)
        {
            OpenXmlPart? openXmlPart;
            try
            {
                openXmlPart = mainDocumentPart.GetPartById(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                openXmlPart = null;
            }

            if (openXmlPart is CustomXmlPart)
            {
                return (CustomXmlPart)openXmlPart;
            }

            if (openXmlPart != null)
            {
                //The part exists, but is not of the correct type, so delete the conflicting relationship.
                mainDocumentPart.DeleteReferenceRelationship(id);
                //Write warning
            }

            return mainDocumentPart.AddCustomXmlPart(CustomXmlPartType.CustomXml, id);
        }

        public static CustomXmlPart? TryGetCustomXmlPart(this MainDocumentPart mainDocumentPart, string id)
        {
            try
            {
                return mainDocumentPart.GetPartById(id) as CustomXmlPart;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        public static WordprocessingDocument CreateFromTemplate(Stream templateStream,
                                                                Stream documentStream,
                                                                string? author = null)
        {
            Contract.Requires(templateStream != null);
            Contract.Requires(documentStream != null);

            WordprocessingDocument? document = null;
            using (var template = WordprocessingDocument.Open(templateStream, false))
            {
                //Creates a copy of the template
                document = (WordprocessingDocument)template.Clone(documentStream, true);
            }

            //Transform the template into a document.
            document.ChangeDocumentType(WordprocessingDocumentType.Document);

            //Set the package properties. Values that are not set here are kept from the template.
            {
                var p = document.PackageProperties;
                //p.Category
                //p.ContentStatus
                //p.ContentType
                p.Created = DateTime.Now;
                p.Creator = author;
                //p.Description
                //p.Identifier
                //p.Keywords
                //p.Language
                p.LastModifiedBy = author;
                p.LastPrinted = null;
                p.Modified = p.Created;
                p.Revision = null;
                //p.Subject
                //p.Title
                //p.Version
            }

            return document;
        }
    }
}
