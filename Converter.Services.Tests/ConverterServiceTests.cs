using Converter.Base;
using Converter.Base.Interfaces;
using Converter.Base.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Converter.Services.Tests.Convert
{
    internal class ConverterServiceTests
    {
        private IConvertService _service;

        private Mock<IConverter> _xmlConverterMock;
        private Mock<IConverter> _jsonConverterMock;
        private Mock<ILogger> _loggerMock;
        private Mock<IStorageHandler> _fileHandlerMock;

        [SetUp]
        public void SetUp()
        {
            _xmlConverterMock = new Mock<IConverter>();
            _jsonConverterMock = new Mock<IConverter>();
            var converters = new List<IConverter>
            {
                _xmlConverterMock.Object,
                _jsonConverterMock.Object
            };
            _loggerMock = new Mock<ILogger>();
            _fileHandlerMock = new Mock<IStorageHandler>();
            var ioHandler = new List<IStorageHandler>
            {
                _fileHandlerMock.Object
            };

            _xmlConverterMock.Setup(c => c.From()).Returns(SupportedFormat.Json);
            _xmlConverterMock.Setup(c => c.To()).Returns(SupportedFormat.Xml);

            _jsonConverterMock.Setup(c => c.From()).Returns(SupportedFormat.Xml);
            _jsonConverterMock.Setup(c => c.To()).Returns(SupportedFormat.Json);

            _fileHandlerMock.Setup(h => h.Type()).Returns(SupportedStorage.FileSystem);

            _service = new ConvertService(ioHandler, converters, _loggerMock.Object);
        }

        [Test]
        public void Unit_example()
        {
            IOConfig config = new IOConfig()
            {
                DestinationType = SupportedStorage.FileSystem,
                SourceType = SupportedStorage.FileSystem,
                PathFrom = "FROM",
                PathTo = "TO"
            };

            _fileHandlerMock.Setup(h => h.Read("FROM")).Returns("xml file");
            _jsonConverterMock.Setup(c => c.Convert("xml file")).Returns("converted json");

            _service.Convert(config, SupportedFormat.Xml, SupportedFormat.Json);

            _fileHandlerMock.Verify(h => h.Write("converted json", "TO"), Times.Once);
        }

    }
}
