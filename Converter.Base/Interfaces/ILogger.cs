using System;

namespace Converter.Base.Interfaces
{
    public interface ILogger
    {
        public void Error(string message, Exception exception = null);
        public void Warning(string message, Exception exception = null);
        public void Information(string message);
        public void Debug(string message);
    }
}
