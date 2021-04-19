using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyPortfolio.Shared;

namespace MyPortfolio.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            UpdateDatabase(host);
            host.Run();
        }

        private static void UpdateDatabase(IHost host)
        {
            try
            {
                using var scope = host.Services.CreateScope();
                scope.ServiceProvider.GetRequiredService<MyPortfolioDbContext>().Database.Migrate();
            }
            catch
            {
                return;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}