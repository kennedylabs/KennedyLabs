using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KennedyLabs
{
    public class Program
    {
        public static void Main(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(l => l.ClearProviders())
                .ConfigureWebHostDefaults(wb => wb.UseStartup<Startup>())
                .Build()
                .Run();
    }
}
