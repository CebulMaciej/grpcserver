using System.Threading.Tasks;
using grpcServer.Grpc.Controllers;
using grpcServer.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Open.Serialization.Json.Newtonsoft;

namespace grpcServer
{
    public static class Program
    {
        public static Task Main(string[] args)
        =>
        WebHost.CreateDefaultBuilder(args).ConfigureKestrel(options =>
        {
            options.ListenAnyIP(5011, o => o.Protocols = 
                HttpProtocols.Http2);
            options.ListenAnyIP(5001, o => o.Protocols =
                HttpProtocols.Http1);
        })
                .ConfigureServices(services =>
                {
                    services.AddControllers().AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    });

                    services.TryAddSingleton(new JsonSerializerFactory().GetSerializer());


                    services
                        .AddInfrastructure()
                        ;

                    services.AddGrpc();
                }).Configure(app =>
                {
                    app
                        .UseRouting()
                        .UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
                        .UseEndpoints(e =>
                        {
                            e.MapControllers();
                            e.MapGrpcService<SenderGrpcController>();
                        });
                })
                .Build()
                .RunAsync();
            
    }
}