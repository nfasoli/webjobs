using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = new HostBuilder()
            .ConfigureWebJobs(b =>
            {
                b.AddTimers();
            })
            .ConfigureLogging(b =>
            {
                b.SetMinimumLevel(LogLevel.Information);
                b.AddConsole();
            })
            .ConfigureServices(s =>
            {
                s.AddSingleton<TimerTriggeredJob>();
            });

        var host = builder.Build();
        using (host)
        {
            await host.RunAsync();
        }
    }
}
