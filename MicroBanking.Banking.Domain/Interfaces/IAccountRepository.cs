using MicroBanking.Banking.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
    }
}
