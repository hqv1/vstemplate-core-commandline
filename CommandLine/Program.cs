using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using CommandLine;
using Console.Actors;
using Data;
using Domain;
using Hqv.CSharp.Common.Map;
using Microsoft.Extensions.Configuration;
using NLog;

namespace Console
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
                if (options == null)
                {
                    throw new Exception("Unable to parse command line");
                }

                var actions = _iocContainer.Resolve<IEnumerable<IActor>>();
                var action = actions.FirstOrDefault(a => a.ShouldAct(options.Value));
                if (action == null)
                {
                    throw new Exception("No action based on options");
                }
                action.Act(options.Value, _config).Wait();                
            }
            catch (Exception ex)
            {
                var logger = _iocContainer.Resolve<ILogger>();
                logger.Error(ex, "Fatal exception");
                System.Console.WriteLine($"Exception. See logs: {ex.Message}");
            }
            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
        }

        /// <summary>
        /// Get configurations
        /// 
        /// todo: add more configuration locations if needed.
        /// </summary>
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
            builder.RegisterInstance(_config).As<IConfiguration>();
            builder.RegisterType<Mapper>().As<IMapper>();

            builder.RegisterType<DbRepository>().As<IDbRepository>();

            //todo: Add registrations
            builder.RegisterType<SayHelloActor>().As<IActor>();
            builder.RegisterType<SayHelloService>();

            _iocContainer = builder.Build();
        }        
    }
}