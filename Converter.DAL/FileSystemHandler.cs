using Converter.Base;
using Converter.Base.Interfaces;
using System.IO;

namespace Converter.DAL
{
    public class FileSystemHandler : IStorageHandler
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public SupportedStorage Type()
        {
            return SupportedStorage.FileSystem;
        }

        public void Write(string input, string path)
        {
            File.WriteAllText(path, input);
        }
    }
}
