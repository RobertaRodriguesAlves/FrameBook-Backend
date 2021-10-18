using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FrameBook.AuthAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();

                   #region Sentry
                   webBuilder.UseSentry(o =>
                   {
                       o.Dsn = "https://64495a904e4348bfb1988222dcd0a53f@o1042932.ingest.sentry.io/6012147";
                       o.Debug = true;
                       o.TracesSampleRate = 1.0;
                   });
                   #endregion
               });
    }
}
