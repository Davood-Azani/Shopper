using Microsoft.Extensions.Hosting;
using Serilog;

namespace Shopper.Application.Extensions
{
    public static class SerilogConfiguration
    {

        public static void ConfigureSerilog(this IHostBuilder builder)
        {
            builder.UseSerilog((context, cfg) =>
            {

                cfg.ReadFrom.Configuration(context.Configuration);


                //MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                //.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
                //.MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                //.MinimumLevel.Override("System", LogEventLevel.Warning)
                //.WriteTo.File("log/Shopper-Api-.log",
                //    rollingInterval: RollingInterval.Day,

                //    rollOnFileSizeLimit: true,
                //    outputTemplate:
                //    "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine} {Message:lj}{NewLine}{Exception}")
                //.WriteTo.Console(
                //    outputTemplate:
                //    "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine} {Message:lj}{NewLine}{Exception}");


            });
        }
    }
}
