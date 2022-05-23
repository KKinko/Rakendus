using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    public class LoansPage : PagedPage<LoanedView, Loaned, ILoansRepo>
    {
        private readonly IReadersRepo readers;
        private readonly IItemsRepo items;
        public LoansPage(ILoansRepo r, IReadersRepo re, IItemsRepo i) : base(r) 
        {
            readers = re;
            items = i;
        }

        protected override Loaned toObject(LoanedView? item) => new LoanedViewFactory().Create(item);

        protected override LoanedView toView(Loaned? entity) => new LoanedViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(LoanedView.ID),
            nameof(LoanedView.ReaderID),
            nameof(LoanedView.ItemID),
            nameof(LoanedView.LoanedDate),
            nameof(LoanedView.LoanedReturned)
        };

        public IEnumerable<SelectListItem> Readers
           => readers?.GetAll(x => x.FirstName)?
           .Select(x => new SelectListItem(x.FirstName, x.ID))
           ?? new List<SelectListItem>();

        public string ReaderName(string? readerID = null)
            => Readers?.FirstOrDefault(x => x.Value == (readerID ?? string.Empty))?.Text ?? "Unspecified";


        public IEnumerable<SelectListItem> BookItems
            => items?.GetAll(x => x.ID)?
            .Select(x => new SelectListItem(x.ID, x.ID))
            ?? new List<SelectListItem>();

        public string ItemName(string? itemID = null)
            => BookItems?.FirstOrDefault(x => x.Value == (itemID ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, LoanedView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(LoanedView.ItemID) ? ItemName(r as string)
                : name == nameof(LoanedView.ReaderID) ? ReaderName(r as string)
                : r;
        }






    }
}
