using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace BixbyShopAppWeb
{
    public class Program
    {
        public static ConcurrentBag<string> serverInstances = new ConcurrentBag<string>();

        public static async Task Main(string[] args)
        {
            await StartServerInstance();
            await Task.Delay(1000); // Delay to ensure the first instance has started before others join

            for (int i = 1; i <= 3; i++)
            {
                await JoinServerInstance(i);
                await Task.Delay(1000);
            }

            CreateHostBuilder(args).Build().Run();
        }

        private static async Task StartServerInstance()
        {
            var hostBuilder = CreateHostBuilder(Array.Empty<string>());

            var ipAddress = GetLocalIpAddress();
            var port = GetAvailablePort();

            var serverInstance = $"{ipAddress}:{port}";

            serverInstances.Add(serverInstance);

            await hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseKestrel(options =>
                {
                    options.Listen(IPAddress.Parse(ipAddress), port);
                });
                webBuilder.UseStartup<Startup>();
            }).Build().RunAsync();
        }

        private static async Task JoinServerInstance(int instanceNumber)
        {
            var hostBuilder = CreateHostBuilder(Array.Empty<string>());

            var ipAddress = GetLocalIpAddress();
            var port = GetAvailablePort();

            var serverInstance = $"{ipAddress}:{port}";

            serverInstances.Add(serverInstance);
            Console.WriteLine($"Server instance {instanceNumber} joined: {serverInstance}");

            var joinUrl = $"http://{serverInstances.First()}/join?instance={serverInstance}";

            using (var client = new WebClient())
            {
                await client.DownloadDataTaskAsync(joinUrl);
            }

            await hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseKestrel(options =>
                {
                    options.Listen(IPAddress.Parse(ipAddress), port);
                });
                webBuilder.UseStartup<Startup>();
            }).Build().RunAsync();
        }

        private static string GetLocalIpAddress()
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }

        private static int GetAvailablePort()
        {
            var listener = new TcpListener(IPAddress.Any, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello from BixbyShopAppWeb!");
                });

                endpoints.MapGet("/join", async context =>
                {
                    var instance = context.Request.Query["instance"];
                    await context.Response.WriteAsync($"Joined server instance: {instance}");
                });
            });
        }
    }
}
