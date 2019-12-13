using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace PlanC.DocumentGeneration.Common
{
    [Serializable]
    public struct TimeDistribution : ISerializable, IXmlSerializable
    {
        public TimeDistribution(int theory, int practice, int homework)
        {
            Contract.Requires(theory >= 0 && practice >= 0 && homework >= 0);

            Theory = theory;
            Practice = practice;
            Homework = homework;
        }

        public TimeDistribution(SerializationInfo info, StreamingContext text)
        {
            Theory = info.GetInt32(nameof(Theory));
            Practice = info.GetInt32(nameof(Practice));
            Homework = info.GetInt32(nameof(Homework));
        }
        
        public int Theory { get; }

        public int Practice { get; }

        public int Homework { get; }

        #region Serialization methods
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Theory), Theory);
            info.AddValue(nameof(Practice), Practice);
            info.AddValue(nameof(Homework), Homework);
        }

        XmlSchema? IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            //writer.WriteAttributeString(nameof(Theory), Theory.ToString(CultureInfo.InvariantCulture));
            //writer.WriteAttributeString(nameof(Practice), Practice.ToString(CultureInfo.InvariantCulture));
            //writer.WriteAttributeString(nameof(Homework), Homework.ToString(CultureInfo.InvariantCulture));

            //Theory
            writer.WriteStartElement(nameof(Theory));
            writer.WriteString(Theory.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            
            //Practice
            writer.WriteStartElement(nameof(Practice));
            writer.WriteString(Practice.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            
            //Homework
            writer.WriteStartElement(nameof(Homework));
            writer.WriteString(Homework.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
        }
        #endregion
    }
}
