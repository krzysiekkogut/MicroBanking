using MicroBanking.Banking.Data.Context;
using MicroBanking.Banking.Domain.Interfaces;
using MicroBanking.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext dbContext;

        public AccountRepository(BankingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await dbContext.Accounts.ToListAsync();
        }
    }
}
