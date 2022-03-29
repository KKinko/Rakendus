using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public sealed class LoanedView: BaseView
    {
        [Display(Name = "Loaned Date")] public DateTime? LoanedDate { get; set; }
        [Display(Name = "Loaned Due")] public DateTime? LoanedDue { get; set; }
        [Display(Name = "Loaned Returned")] public DateTime? LoanedReturned { get; set; }
        [Display(Name = "Overdue Fine")] public int? OverdueFine { get; set; }
        [Display(Name = "Loaned Status")] public bool? LoanedStatus { get; set; }
    }
    public sealed class LoanedViewFactory : BaseViewFactory<LoanedView, Loaned, LoanedData>
    {
        protected override Loaned toEntity(LoanedData d) => new(d);
    }
}
