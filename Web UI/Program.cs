using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Web_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch
            {
                CreateAltHostBuilder(args).Build().Run();
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
                         int port = 5050;
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
