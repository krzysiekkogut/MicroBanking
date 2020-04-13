using MediatR;
using MicroBanking.Banking.Application.Interfaces;
using MicroBanking.Banking.Application.Services;
using MicroBanking.Banking.Data.Context;
using MicroBanking.Banking.Data.Repository;
using MicroBanking.Banking.Domain.CommandHandlers;
using MicroBanking.Banking.Domain.Commands;
using MicroBanking.Banking.Domain.Interfaces;
using MicroBanking.Domain.Core.Bus;
using MicroBanking.Infrastructure.Bus;
using MicroBanking.Transfer.Application.Interfaces;
using MicroBanking.Transfer.Application.Services;
using MicroBanking.Transfer.Data.Context;
using MicroBanking.Transfer.Data.Repository;
using MicroBanking.Transfer.Domain.EventHandlers;
using MicroBanking.Transfer.Domain.Events;
using MicroBanking.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroBanking.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Transfer Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            // Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            // Data
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
        }
    }
}
