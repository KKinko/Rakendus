using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class LoanedViewFactoryTests : ViewFactoryTests<LoanedViewFactory, LoanedView, Loaned, LoanedData>
    {
        protected override Loaned toObject(LoanedData d) => new(d);
    }
}
