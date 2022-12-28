using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;

namespace dotnet_isolated_http_example {
    class Program {
        static async Task Main(string[] args) {
            var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .Build();

            await host.RunAsync();

        }
    }
}
