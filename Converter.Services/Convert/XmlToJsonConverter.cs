using Converter.Base;
using Converter.Base.Interfaces;
using Newtonsoft.Json;
using System.Xml;

namespace Converter.Services.Convert
{
    public class XmlToJsonConverter : IConverter
    {
        public string Convert(string input)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(input);
            return JsonConvert.SerializeXmlNode(doc);
        }

        public SupportedFormat From()
        {
            return SupportedFormat.Xml;
        }

        public SupportedFormat To()
        {
            return SupportedFormat.Json;
        }
    }
}
