using ChaseLabs.Games.SWF.STDLib.Global;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace Web_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Functions.GrabAssAsync();
            try
            {
                CreateAltHostBuilder(args).Build().Run();
            }
            catch
            {
                CreateHostBuilder(args).Build().Run();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseContentRoot(System.IO.Directory.GetCurrentDirectory());
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
        public static IHostBuilder CreateAltHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>().UseKestrel(options =>
                     {
                         int port = Values.Port;
                         if (args.Length > 0)
                         {
                             int.TryParse(args[0], out port);
                         }

                         if (args.Length > 2)
                         {
                             options.ListenAnyIP(port, listenOptions =>
                             {
                                 listenOptions.UseHttps(args[1], args[2]);
                             });
                         }
                         else
                         {
                             options.ListenAnyIP(port);
                         }
                     });
                 });
    }
}
