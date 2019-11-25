﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace PlanC.DocumentGeneration.CourseTemplate
{
    public class DocumentEditor : DocumentEditorBase<CourseTemplate>
    {
        public DocumentEditor(WordprocessingDocument document) : base(document)
        { }

        protected override XslCompiledTransform CreateMainDocumentPartStyleSheet()
        {
            var location = @"res:PlanC.DocumentGeneration.Templates/CourseTemplateMainDocumentPart.xslt";
            var stylesheet = new XslCompiledTransform();
            stylesheet.Load(location, XsltSettings.Default, new XmlResourceResolver(typeof(DocumentEditor).Assembly));

            return stylesheet;
        }
    }
}
