using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Sentry;

namespace ToSoftware.Shop.Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            SentrySdk.CaptureMessage("tosoftware-shop-catalog up");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Add the following line:
                    webBuilder.UseSentry(o =>
                    {
                        o.Dsn = "https://d2825b7ba6564b3e8ffc59cb3eb6e18d@o265796.ingest.sentry.io/5812452";
                        // When configuring for the first time, to see what the SDK is doing:
                        o.Debug = true;
                        // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                        // We recommend adjusting this value in production.
                        o.TracesSampleRate = 1.0;
                    });
                });
    }
}