
namespace Rakendus.Data.Party
{
    public sealed class LoanedData : UniqueData
    {
        
        public DateTime? LoanedDate { get; set; }
        public DateTime? LoanedReturned { get; set; }
        public string? ItemID { get; set; }
        public string? ReaderID { get; set; }
    }
}
