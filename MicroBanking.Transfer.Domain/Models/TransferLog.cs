namespace MicroBanking.Transfer.Domain.Models
{
    public class TransferLog
    {
        public int Id { get; set; }
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
