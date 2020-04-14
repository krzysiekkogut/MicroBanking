namespace MicroBanking.UI.Models
{
    public class TransferViewModel
    {
        public string TransferNotes { get; set; }
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
