using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Xsl;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    public class DocumentEditor : DocumentEditorBase<CourseTemplate>
    {
        public DocumentEditor(WordprocessingDocument document) : base(document)
        { }

        protected override XslCompiledTransform CreateMainDocumentPartStyleSheet()
        {
            var location = @"J:\À conserver\Session A2019\Projet\PlanC\src\PlanC.DocumentGeneration\CourseTemplate\MainPartTemplate.xslt";
            var stylesheet = new XslCompiledTransform();
            stylesheet.Load(location);
            return stylesheet;
        }
    }
}
