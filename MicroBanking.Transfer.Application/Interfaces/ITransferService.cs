using MicroBanking.Transfer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        Task<IEnumerable<TransferLog>> GetAllAsync();
    }
}
