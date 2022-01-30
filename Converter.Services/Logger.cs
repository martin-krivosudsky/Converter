using Converter.Base.Interfaces;
using System;

namespace Converter.Services
{
    public class Logger : ILogger
    {
        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception exception = null)
        {
            LogInternal(message, exception);
        }

        public void Information(string message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message, Exception exception = null)
        {
            throw new NotImplementedException();
        }

        private void LogInternal(/*logLevel*/ string message, Exception exception)
        {
            Console.WriteLine(message);
            Console.WriteLine(exception.ToString());
        }
    }
}
