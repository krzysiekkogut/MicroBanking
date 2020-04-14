namespace MicroBanking.UI.Models.Dto
{
    public class TransferDto
    {
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
