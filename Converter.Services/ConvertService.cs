using Converter.Base;
using Converter.Base.Interfaces;
using Converter.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Converter.Services
{
    public class ConvertService : IConvertService
    {
        private readonly IEnumerable<IStorageHandler> _storageHandlers;
        private readonly IEnumerable<IConverter> _converters;
        private readonly ILogger _logger;

        public ConvertService(
            IEnumerable<IStorageHandler> storageHandlers,
            IEnumerable<IConverter> converters,
            ILogger logger)
        {
            _storageHandlers = storageHandlers ?? throw new ArgumentNullException(nameof(storageHandlers));
            _converters = converters ?? throw new ArgumentNullException(nameof(converters));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Convert(IOConfig config, SupportedFormat formatFrom, SupportedFormat formatTo)
        {
            var sourceHandler = _storageHandlers.FirstOrDefault(s => s.Type() == config.SourceType);
            var destinationHandler = _storageHandlers.FirstOrDefault(s => s.Type() == config.DestinationType);
            var converter = _converters.FirstOrDefault(c => c.From() == formatFrom && c.To() == formatTo);

            if (sourceHandler == null)
            {
                _logger.Error($"Usupported source storage - {config.SourceType}");
                return;
            }
            if (destinationHandler == null)
            {
                _logger.Error($"Usupported destination storage - {config.DestinationType}");
                return;
            }
            if (converter == null)
            {
                _logger.Error($"Convert from {formatFrom} to {formatTo} not supported yet");
                return;
            }

            string output;

            try
            {
                string input = sourceHandler.Read(config.PathFrom);
                output = converter.Convert(input);
            }
            catch(Exception exception)
            {
                _logger.Error("Error converting", exception);
                return;
            }

            destinationHandler.Write(output, config.PathTo);
        }
    }
}
