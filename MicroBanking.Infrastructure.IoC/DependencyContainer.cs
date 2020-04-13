using MicroBanking.Banking.Application.Interfaces;
using MicroBanking.Banking.Application.Services;
using MicroBanking.Banking.Data.Context;
using MicroBanking.Banking.Data.Repository;
using MicroBanking.Banking.Domain.Interfaces;
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

            // Aplication Services
            services.AddTransient<IAccountService, AccountService>();

            // Data
            services.AddTransient<BankingDbContext>();
            services.AddTransient<IAccountRepository, AccountRepository>();
        }
    }
}
