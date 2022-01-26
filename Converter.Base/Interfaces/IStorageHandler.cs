namespace Converter.Base.Interfaces
{
    public interface IStorageHandler
    {
        public void Write(string input, string path);
        public string Read(string path);
        public SupportedStorage Type();
    }
}
