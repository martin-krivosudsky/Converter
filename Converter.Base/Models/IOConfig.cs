namespace Converter.Base.Models
{
    public class IOConfig
    {
        public SupportedStorage SourceType { get; set; }
        public SupportedStorage DestinationType { get; set; }
        public string PathFrom { get; set; }
        public string PathTo { get; set; }
    }
}
