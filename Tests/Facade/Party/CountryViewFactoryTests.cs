using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class CountryViewFactoryTests 
        : ViewFactoryTests<CountryViewFactory, CountryView, Country, CountryData> {
        protected override Country toObject(CountryData d) => new(d);
    }
}
