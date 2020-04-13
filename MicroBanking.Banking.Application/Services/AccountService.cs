using MicroBanking.Banking.Application.Interfaces;
using MicroBanking.Banking.Domain.Interfaces;
using MicroBanking.Banking.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
