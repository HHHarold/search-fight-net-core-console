using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace SearchFight.ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddCustomConfig()                
                .AddCustomServices()
                .AddCustomApiClients()
                .AddCustomServiceMappers()                
                .BuildServiceProvider();
                        
            serviceProvider.GetService<ConsoleApplication>().Run(args);            
        }
    }
}
