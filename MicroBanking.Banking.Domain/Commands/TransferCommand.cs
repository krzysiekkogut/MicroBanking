using MicroBanking.Domain.Core.Commands;

namespace MicroBanking.Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public int SourceAccountId { get; protected set; }
        public int TargetAccountId { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}
