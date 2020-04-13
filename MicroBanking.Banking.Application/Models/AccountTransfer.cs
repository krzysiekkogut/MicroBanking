namespace MicroBanking.Banking.Application.Models
{
    public class AccountTransfer
    {
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
