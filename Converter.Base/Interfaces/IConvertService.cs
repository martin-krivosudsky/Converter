using Converter.Base.Models;

namespace Converter.Base.Interfaces
{
    public interface IConvertService
    {
        public void Convert(IOConfig config, SupportedFormat formatFrom, SupportedFormat fromatTo);
    }
}
