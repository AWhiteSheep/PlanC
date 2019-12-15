using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace PlanC.DocumentGeneration
{
    /// <summary>
    ///     Base class for a strongly typed <see cref="WordprocessingDocument"/> editor.
    /// </summary>
    /// <typeparam name="TModel">
    ///     The type of the model with the data contained in the document. It must be a reference type and contain an
    ///     empty constructor initializing the object to empty values.
    /// </typeparam>
    public abstract class DocumentEditorBase<TModel> where TModel : class, new()
    {
        private TModel? _model;
        private XmlSerializer? _modelSerializer;
        private XslCompiledTransform? _mainDocumentPartStyleSheet;

        protected DocumentEditorBase(WordprocessingDocument document)
        {
            Document = document ?? throw new ArgumentNullException(nameof(document));
        }


        //Abstract members that need to be overriden for this class to work.

        protected abstract XslCompiledTransform CreateMainDocumentPartStyleSheet();


        //Virtual members implementation

        protected virtual string ModelCustomPartId => "model";

        /// <summary>
        ///     Creates a new instance of the <see cref="XmlSerializer"/> to use when serializing or deserializing the
        ///     <see cref="Model"/>.
        /// </summary>
        /// <returns>
        ///     A fully configured instance of <see cref="XmlSerializer"/> or a subclass.
        /// </returns>
        protected virtual XmlSerializer CreateModelSerializer()
        {
            return new XmlSerializer(typeof(TModel));
        }


        //Non-virtual members implementation

        /// <summary>
        ///     Gets the <see cref="WordprocessingDocument"/> that this editor works on.
        /// </summary>
        protected WordprocessingDocument Document { get; }

        /// <summary>
        ///     Gets a cached instance of the <see cref="XmlSerializer"/> to use when serializing or deserializing the
        ///     <see cref="Model"/>.
        /// </summary>
        protected XmlSerializer ModelSerializer => _modelSerializer ?? (_modelSerializer = CreateModelSerializer());

        /// <summary>
        ///     Gets a cached instance of the XSLT stylesheet for the main document part.
        /// </summary>
        protected XslCompiledTransform MainDocumentPartStyleSheet
        {
            get
            {
                if (_mainDocumentPartStyleSheet == null)
                {
                    _mainDocumentPartStyleSheet = CreateMainDocumentPartStyleSheet();
                    Contract.Ensures(_mainDocumentPartStyleSheet.OutputSettings.OmitXmlDeclaration);
                }
                return _mainDocumentPartStyleSheet;
            }
        }

        /// <summary>
        ///     Gets or sets the model with the data of this document.
        /// </summary>
        /// <remarks>
        ///     This value is never null. When the document has no model part attached, this property is set to an
        ///     empty model.
        /// </remarks>
        public TModel Model
        {
            get
            {
                if (_model == null)
                {
                    var part = Document?.MainDocumentPart?.TryGetCustomXmlPart(ModelCustomPartId);
                    if (part == null)
                    {
                        _model = new TModel();
                    }
                    else
                    {
                        using (var modelStream = part.GetStream())
                        {
                            _model = (TModel)ModelSerializer.Deserialize(modelStream);
                        }
                    }
                }

                return _model;
            }
            set
            {
                _model = value;
            }
        }

        /// <summary>
        ///     Applies the changes made by this editor to the underlying <see cref="WordprocessingDocument"/>.
        /// </summary>
        public void ApplyChanges()
        {
            if (_model == null)
            {
                //The model has not been get, so no changes are needed.
                return;
            }

            //STEP 1: Serialize the document model into a memory stream.

            using (var dataSourceStream = new MemoryStream())
            {
                ModelSerializer.Serialize(dataSourceStream, _model);
                
                //STEP 2: Generate the document's XML using the serialized data and the XSLT stylesheet.
                
                //Prepare the data source stream to be read.
                dataSourceStream.Flush();
                dataSourceStream.Position = 0L;

                var documentXml = (string?)null;
                using (var documentStream = new MemoryStream())
                using (var dataXmlReader = XmlReader.Create(dataSourceStream))
                {
                    //Perform the transformation. It is important that we use the overload that outputs to a stream
                    //since it will create a XmlWriter that respects the options defined in the xsl:option element in
                    //the Xslt files.
                    MainDocumentPartStyleSheet.Transform(dataXmlReader, null, documentStream);

                    //Prepare the document stream to be read.
                    documentStream.Flush();
                    documentStream.Position = 0L;

                    //Get the transformed document as a string
                    using (var documentReader = new StreamReader(documentStream))
                    {
                        documentXml = documentReader.ReadToEnd();
                    }
                }

                Debug.Assert(documentXml != null);

                //STEP 3: Embed the data into the document as a custom XML part.
                //Get or add the main part of the Open XML document
                var mainDocPart = Document.GetOrAddMainDocumentPart();

                //Prepare the data source stream to be read. Again.
                dataSourceStream.Position = 0L;

                //Set the document model part
                using (var modelCustomPartStream = mainDocPart.GetOrAddCustomXmlPart(ModelCustomPartId).GetStream()) //TODO
                {
                    //Clear any existing data in the part
                    modelCustomPartStream.SetLength(0L);

                    //Copy the serialized data into the part's stream
                    dataSourceStream.CopyTo(modelCustomPartStream);
                }

                //STEP 4: Set the document to the new XML
                mainDocPart.Document = new Document(documentXml);
            }
        }


        //Private helpers

        
    }
}
