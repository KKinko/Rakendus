using System.ComponentModel.DataAnnotations;

namespace Rakendus.Data.Party
{
    public sealed class LoanedData : EntityData
    {
        public DateTime? LoanedDate { get; set; }
        public DateTime? LoanedDue { get; set; }
        public DateTime? LoanedReturned { get; set; }
        public int? OverdueFine { get; set; }
        public bool? LoanedStatus { get; set; }
    }
}
