using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography.X509Certificates;

namespace BixbyShopAppWeb_LK
{
    public class WebServer
    {
        private static IWebHost host;

        public WebServer()
        {
            var certificate = new X509Certificate2("path_to_certificate.pfx", "certificate_password");
            var httpsOptions = new HttpsConnectionAdapterOptions()
            {
                ServerCertificate = certificate
            };

            host = new WebHostBuilder()
            .UseKestrel(options => options.ListenAnyIP(443, listenOptions => listenOptions.UseHttps(httpsOptions)))
                .ConfigureServices(services => services.AddSingleton(this))
                .Configure(app => app.Run(HandleRequest))
                .Build();
        }

        public static void Start()
        {
            host.Run();
        }

        public static void Stop()
        {
            host?.StopAsync().Wait();
            host?.Dispose();
        }

        private static Task HandleRequest(HttpContext context)
        {
           
            return Task.CompletedTask;
        }
    }
}
