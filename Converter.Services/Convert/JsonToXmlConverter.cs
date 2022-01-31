using Converter.Base;
using Converter.Base.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace Converter.Services.Convert
{
    public class JsonToXmlConverter : IConverter
    {
        public string Convert(string input)
        {
            XmlDocument xml = JsonConvert.DeserializeXmlNode(input);

            using StringWriter stringWriter = new StringWriter();
            using XmlTextWriter textWriter = new XmlTextWriter(stringWriter);
            xml.WriteTo(textWriter);
            string xmlString = stringWriter.ToString();
            return xmlString;
        }

        public SupportedFormat From()
        {
            return SupportedFormat.Json;
        }

        public SupportedFormat To()
        {
            return SupportedFormat.Xml;
        }
    }
}
