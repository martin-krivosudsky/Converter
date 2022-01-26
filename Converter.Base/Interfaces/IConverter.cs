namespace Converter.Base.Interfaces
{
    public interface IConverter
    {
        public string Convert(string input);
        public SupportedFormat From();
        public SupportedFormat To();
    }
}
