using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class CurrencyViewFactoryTests 
        : ViewFactoryTests<CurrencyViewFactory, CurrencyView, Currency, CurrencyData>  {
        protected override Currency toObject(CurrencyData d) => new(d);
    }
}
