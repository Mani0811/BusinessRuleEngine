using BusinessRulesEngine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace BusinessRulesEngine
{
   
    class Program   
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public static IServiceProvider servicesProvider = null;
        static void Main(string[] args)
        {
           
            PerformUserAction();
            Console.Read();
        }

        private static void PerformUserAction()
        {
            try
            {
                var config = new ConfigurationBuilder()
                  .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .Build();

                servicesProvider = BuildDi(config);
                var ruleEngine = servicesProvider.GetRequiredService<RuleEngine>();
                ruleEngine.AddRule();
                var ids = new List<int> {1,2,3,4,5,6};
                foreach (var id in ids)
                {
                    var rule = ruleEngine.Rules[id];
                    ruleEngine.Perform(rule);
                }
            }
            catch (Exception ex)
            {
                // NLog: catch any exception and log it.
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }

        }

        private static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
               .AddTransient<RuleEngine>()
               .AddTransient<Rule>()
               .AddLogging(loggingBuilder =>
               {
                   // configure Logging with NLog
                   loggingBuilder.ClearProviders();
                   loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                   loggingBuilder.AddNLog(config);
               })
               .BuildServiceProvider();
        }
    }
}
