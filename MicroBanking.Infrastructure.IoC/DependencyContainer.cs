using MicroBanking.Domain.Core.Bus;
using MicroBanking.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroBanking.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
