using Converter.Base.Interfaces;
using Converter.Services.Convert;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Converter.Services.Tests.Convert
{
    internal class JsonToXmlConverterTests
    {
        private readonly IConverter _service = new JsonToXmlConverter();

        [Test]
        public void Convert_ValidInput_ValidOutput()
        {
            string result = _service.Convert(FileExamples.JsonFile);

            Assert.AreEqual(FileExamples.XmlFile, result);
        }

        [Test]
        public void Convert_InvalidInput_ExceptionThrown()
        {
            Assert.Throws<JsonReaderException>(() => _service.Convert("invalid json"));
        }
    }
}
