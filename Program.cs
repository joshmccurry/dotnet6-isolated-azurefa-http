using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.Azure.Functions.Worker;
using Grpc.Core;

namespace dotnet_isolated_http_example {
    class Program {
        static async Task Main(string[] args) {
            var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults() //Load Worker Defaults

            .ConfigureLogging((context, builder) => {
                builder.AddApplicationInsights(
                    //Add the AI connection string to the local.settings.json and Azure app settings
                    configureTelemetryConfiguration: (config) => config.ConnectionString = context.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"],
                    configureApplicationInsightsLoggerOptions: (options) => { }
                );

                // Capture all log-level entries from Program
                builder.AddFilter<ApplicationInsightsLoggerProvider>(
                    typeof(Program).FullName, LogLevel.Trace);

            })
            .Build();

            await host.RunAsync();

        }
    }
}
