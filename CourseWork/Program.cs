using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace CourseWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при запуске приложения: {ex.Message}");
                throw;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    if (webBuilder == null)
                    {
                        throw new ArgumentNullException(nameof(webBuilder), "Web host builder не может быть null.");
                    }

                    webBuilder.UseStartup<StartUp>();
                });
    }
}