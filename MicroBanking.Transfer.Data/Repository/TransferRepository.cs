using MicroBanking.Transfer.Data.Context;
using MicroBanking.Transfer.Domain.Interfaces;
using MicroBanking.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext dbContext;

        public TransferRepository(TransferDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TransferLog>> GetAllAsync()
        {
            return await dbContext.Transfers.ToListAsync();
        }
    }
}
