using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

namespace Serilog03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseSerilog((hostingContect, loggerConfiguration) => loggerConfiguration
                .ReadFrom.Configuration(hostingContect.Configuration)
                .WriteTo.Console(new CompactJsonFormatter())
            );
    }
}
