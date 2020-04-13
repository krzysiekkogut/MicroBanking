using MicroBanking.Domain.Core.Bus;
using MicroBanking.Transfer.Domain.Events;
using System.Threading.Tasks;

namespace MicroBanking.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        public Task Handle(TransferCreatedEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
