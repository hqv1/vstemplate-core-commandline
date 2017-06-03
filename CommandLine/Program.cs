using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using NLog;

namespace CommandLine
{
    internal class Program
    {
        private static IConfigurationRoot _config;
        private static IContainer _iocContainer;

        private static void Main(string[] args)
        {
            GetConfigurationRoot();
            RegisterComponents();

            try
            {
                var options = Parser.Default.ParseArguments<Options>(args) as Parsed<Options>;

                //todo: do work based on the options
            }
            catch (Exception ex)
            {
                var logger = _iocContainer.Resolve<ILogger>();
                logger.Error(ex, "Unhandled exception");
                Console.WriteLine($"Unhandled exception. See logs: {ex.Message}");
            }
        }

        private static void GetConfigurationRoot()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        /// <summary>
        /// IOC container using Autofac (https://autofac.org/)
        /// </summary>
        private static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.Register(x => LogManager.GetLogger("console")).As<ILogger>();
            builder.RegisterType<Mapper>().As<IMapper>();
            
            //todo: Add registrations

            _iocContainer = builder.Build();
        }        
    }
}