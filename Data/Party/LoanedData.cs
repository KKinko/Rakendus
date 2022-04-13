using System.ComponentModel.DataAnnotations;

namespace Rakendus.Data.Party
{
    public sealed class LoanedData : EntityData
    {
        public string? BookItem { get; set; }
        public string? Reader { get; set; }
        public DateTime? LoanedDate { get; set; }
        public DateTime? LoanedReturned { get; set; }
    }
}
