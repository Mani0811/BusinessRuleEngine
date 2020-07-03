using Microsoft.Extensions.Logging;
using NLog;
using System;

namespace BusinessRulesEngine
{
    public static class Helper
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public static void PerformCondtionAction(Item item)
        {
            Console.WriteLine($"Payment is done for " + (item as ProductItem)?.Name);
        }

        public static void PerformResultAction(Item targetValue, string msg)
        {
            Console.WriteLine(msg + " " + targetValue.Name);
        }

        public static void LogException( Exception ex)
        {
            logger.Error(ex);
        }
    }




}