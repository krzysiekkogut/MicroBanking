using MediatR;
using MicroBanking.Banking.Domain.Commands;
using MicroBanking.Banking.Domain.Events;
using MicroBanking.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBanking.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand>
    {
        private readonly IEventBus eventBus;

        public TransferCommandHandler(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public Task<Unit> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            eventBus.Publish(
               new TransferCreatedEvent(
                   request.SourceAccountId,
                   request.TargetAccountId,
                   request.Amount)
               );
            return Unit.Task;
        }
    }
}
