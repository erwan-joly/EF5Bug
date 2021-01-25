using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NodaTime;

namespace EF3
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(
                    loggingBuilder => {
                        loggingBuilder.ClearProviders();
                    }
                )
                .ConfigureServices((hostContext, services) => {
                    services.Configure<ConsoleLifetimeOptions>(options => options.SuppressStatusMessages = true);
                    services.AddSingleton<IClock>(SystemClock.Instance);
                    services.AddDbContext<TestContext>(options =>
                        options.UseNpgsql("User ID=postgres;Password=password;Host=127.0.0.1;Port=5432;Database=postgres;", o => o.UseNodaTime()));
                    services.AddHostedService<Worker>();
                });
        }
    }
}