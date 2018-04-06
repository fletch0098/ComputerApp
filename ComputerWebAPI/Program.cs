using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Xml;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ComputerDAL;
using ComputerLibrary.Models;
using NLog;
using NLog.Web;
using NLog.Web.AspNetCore;

namespace ComputerWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //XmlDocument log4netConfig = new XmlDocument();
            //log4netConfig.Load(File.OpenRead("log4net.config"));
            //var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            //log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            //log.Info("App Start");

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<Program>>();

                logger.LogInformation("Application Start");

                try
                {
                    var context = services.GetRequiredService<ComputerContext>();

                    var dbInitializer = services.GetRequiredService<DbInitializer>();

                    dbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }

                host.Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()

                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    logging.AddAzureWebAppDiagnostics();
                    logging.AddDebug();
                })

                .UseNLog()  // NLog: setup NLog for Dependency injection

                .Build();
    }
}
