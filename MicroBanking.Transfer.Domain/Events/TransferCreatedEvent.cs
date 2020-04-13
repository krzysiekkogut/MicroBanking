using MicroBanking.Domain.Core.Events;

namespace MicroBanking.Transfer.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public int SourceAccountId { get; private set; }
        public int TargetAccountId { get; private set; }
        public decimal Amount { get; private set; }

        public TransferCreatedEvent(int sourceAccountId, int targetAccountId, decimal amount)
        {
            SourceAccountId = sourceAccountId;
            TargetAccountId = targetAccountId;
            Amount = amount;
        }
    }
}
