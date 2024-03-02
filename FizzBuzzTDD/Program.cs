
using FizzBuzzTDD.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FizzBuzzTDD
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                var host = CreateHostBuilder(args).Build();
                var serviceProvider = host.Services;

                using (var scope = serviceProvider.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var fizzBuzz = services.GetRequiredService<FizzBuzzService>();

                        Console.WriteLine("Enter start value:");
                        int start = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter end value:");
                        int end = int.Parse(Console.ReadLine());

                        var result = fizzBuzz.GenerateFizzBuzz(start, end);

                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("End of program.");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred while running. {ex}");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred. {ex}");
            }

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<FizzBuzzService>();

                });
    }
}