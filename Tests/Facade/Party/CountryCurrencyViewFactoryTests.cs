using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class CountryCurrencyViewFactoryTests 
        : ViewFactoryTests<CountryCurrencyViewFactory, CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency toObject(CountryCurrencyData d) => new(d);
    }
}
