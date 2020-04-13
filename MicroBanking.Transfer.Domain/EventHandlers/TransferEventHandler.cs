using MicroBanking.Domain.Core.Bus;
using MicroBanking.Transfer.Domain.Events;
using MicroBanking.Transfer.Domain.Interfaces;
using MicroBanking.Transfer.Domain.Models;
using System.Threading.Tasks;

namespace MicroBanking.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            this.transferRepository = transferRepository;
        }

        public async Task Handle(TransferCreatedEvent @event)
        {
            await transferRepository.AddAsync(new TransferLog
            {
                SourceAccountId = @event.SourceAccountId,
                TargetAccountId = @event.TargetAccountId,
                Amount = @event.Amount,
            });
        }
    }
}
