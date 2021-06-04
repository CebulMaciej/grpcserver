using grpcServer.Infrastructure.Services.Abstract;
using grpcServer.Infrastructure.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace grpcServer.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddSingleton<IMessagesRepository, MessagesRepository>();   
            return serviceProvider;
        }
    }
}