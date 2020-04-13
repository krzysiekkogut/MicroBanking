using Microsoft.EntityFrameworkCore;
using MicroBanking.Transfer.Domain.Models;

namespace MicroBanking.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransferLog> Transfers { get; set; }
    }
}
