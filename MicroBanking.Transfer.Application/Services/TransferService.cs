using MicroBanking.Domain.Core.Bus;
using MicroBanking.Transfer.Application.Interfaces;
using MicroBanking.Transfer.Domain.Interfaces;
using MicroBanking.Transfer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository transferRepository;
        private readonly IEventBus eventBus;

        public TransferService(ITransferRepository transferRepository, IEventBus eventBus)
        {
            this.transferRepository = transferRepository;
            this.eventBus = eventBus;
        }

        public async Task<IEnumerable<TransferLog>> GetAllAsync()
        {
            return await transferRepository.GetAllAsync();
        }
    }
}
