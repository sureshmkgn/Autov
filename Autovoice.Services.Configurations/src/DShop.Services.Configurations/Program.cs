using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autovoice.Common.Logging;
using Autovoice.Common.Metrics;
using Autovoice.Common.Mvc;
using Autovoice.Common.Vault;

namespace Autovoice.Services.Configurations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseVault()
                .UseLockbox()
                .UseAppMetrics();
    }
}