using Converter.Base;
using Converter.Base.Interfaces;

namespace Converter.DAL
{
    public class HttpHandler : IStorageHandler
    {
        public string Read(string path)
        {
            throw new System.NotImplementedException();
        }

        public SupportedStorage Type()
        {
            throw new System.NotImplementedException();
        }

        public void Write(string input, string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
