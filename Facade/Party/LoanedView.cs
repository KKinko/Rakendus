using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public sealed class LoanedView: UniqueView
    {

        [DisplayName("Book Item")] public string? ItemID { get; set; }
        [DisplayName("Reader")] public string? ReaderID { get; set; }
        [DisplayName("Loaned Date")] public DateTime? LoanedDate { get; set; }
        [DisplayName("Loaned Returned")] public DateTime? LoanedReturned { get; set; }


    }
    public sealed class LoanedViewFactory : BaseViewFactory<LoanedView, Loaned, LoanedData>
    {
        protected override Loaned toEntity(LoanedData d) => new(d);
    }
}
