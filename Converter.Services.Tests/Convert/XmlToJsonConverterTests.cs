using Converter.Base.Interfaces;
using Converter.Services.Convert;
using NUnit.Framework;
using System.Xml;

namespace Converter.Services.Tests.Convert
{
    internal class XmlToJsonConverterTests
    {
        private readonly IConverter _service = new XmlToJsonConverter();

        [Test]
        public void Convert_ValidInput_ValidOutput()
        {
            string result = _service.Convert(FileExamples.XmlFile);

            Assert.AreEqual(FileExamples.JsonFile, result);
        }

        [Test]
        public void Convert_InvalidInput_ExceptionThrown()
        {
            Assert.Throws<XmlException>(() => _service.Convert("invalid xml"));
        }
    }
}
