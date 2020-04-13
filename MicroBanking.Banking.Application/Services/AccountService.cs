using MicroBanking.Banking.Application.Interfaces;
using MicroBanking.Banking.Application.Models;
using MicroBanking.Banking.Domain.Commands;
using MicroBanking.Banking.Domain.Interfaces;
using MicroBanking.Banking.Domain.Models;
using MicroBanking.Domain.Core.Bus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        private readonly IEventBus eventBus;

        public AccountService(IAccountRepository repository, IEventBus eventBus)
        {
            this.repository = repository;
            this.eventBus = eventBus;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.SourceAccountId,
                accountTransfer.TargetAccountId,
                accountTransfer.Amount);
            eventBus.SendCommand(createTransferCommand);
        }
    }
}
