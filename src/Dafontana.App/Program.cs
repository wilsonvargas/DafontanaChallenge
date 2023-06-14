using Dafontana.App.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dafontana.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = Startup.ConfigureServices();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<QueryExecutor>().Run();
            Console.ReadLine();
        }
    }
}
