namespace Converter.Base.Interfaces
{
    public interface IConvertService
    {
        public void Convert(string pathFrom, string pathTo, SupportedFormat formatFrom, SupportedFormat fromatTo);
    }
}
