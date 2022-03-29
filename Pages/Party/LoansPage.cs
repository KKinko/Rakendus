using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages
{
    public class LoansPage : BasePage<LoanedView, Loaned, ILoansRepo>
    {
        public LoansPage(ILoansRepo r) : base(r) { }

        protected override Loaned toObject(LoanedView? item) => new LoanedViewFactory().Create(item);

        protected override LoanedView toView(Loaned? entity) => new LoanedViewFactory().Create(entity);
    }
}
