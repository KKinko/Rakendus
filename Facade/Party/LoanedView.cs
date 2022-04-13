using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public sealed class LoanedView: BaseView
    {
       
        [Display(Name = "Book Item")] public string? BookItem { get; set; }
        [Display(Name = "Reader")] public string? Reader { get; set; }
        [Display(Name = "Loaned Date")] public DateTime? LoanedDate { get; set; }
        [Display(Name = "Loaned Returned")] public DateTime? LoanedReturned { get; set; }


    }
    public sealed class LoanedViewFactory : BaseViewFactory<LoanedView, Loaned, LoanedData>
    {
        protected override Loaned toEntity(LoanedData d) => new(d);
    }
}
