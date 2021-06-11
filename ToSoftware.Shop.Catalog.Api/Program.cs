using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Sentry;
using Serilog;
using Serilog.Events;

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
                    Log.Logger = new LoggerConfiguration()
                      .WriteTo.Sentry(o =>
                      {
                          o.MinimumBreadcrumbLevel = LogEventLevel.Debug;

                          o.MinimumEventLevel = LogEventLevel.Information;

                          o.Dsn = "https://d2825b7ba6564b3e8ffc59cb3eb6e18d@o265796.ingest.sentry.io/5812452";
                          o.Debug = true;
                          o.AttachStacktrace = true;
                          o.SendDefaultPii = true;
                          o.TracesSampleRate = 1.0;
                          o.DiagnosticLevel = SentryLevel.Debug;
                      })
                      .CreateLogger();

                    webBuilder.UseStartup<Startup>();
                });
    }
}