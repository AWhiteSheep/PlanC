#nullable enable

using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanC.DocumentGeneration
{
    internal static class OpenXmlExtensions
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
    }
}
