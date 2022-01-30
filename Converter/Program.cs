using Converter.Base.Interfaces;
using Converter.DAL;
using Converter.Services;
using Converter.Services.Convert;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Moravia.Homework
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var convertServicer = host.Services.GetService<IConvertService>();

            //convertServicer.Convert(args.Parsed);

            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services.AddSingleton<IConverter, XmlToJsonConverter>()
                    .AddSingleton<IConverter, XmlToJsonConverter>()
                    .AddSingleton<IConvertService, ConvertService>()
                    .AddSingleton<ILogger, Logger>()
                    .AddSingleton<IStorageHandler, FileSystemHandler>()
        );
    }
}