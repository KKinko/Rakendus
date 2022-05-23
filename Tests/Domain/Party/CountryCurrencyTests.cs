using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party {
    [TestClass] public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>> {
        protected override CountryCurrency createObj() => new(GetRandom.Value<CountryCurrencyData>());
        [TestMethod] public void CountryIDTest() => isReadOnly(obj.Data.CountryID);
        [TestMethod] public void CurrencyIDTest() => isReadOnly(obj.Data.CurrencyID);
        [TestMethod] public void CountryTest() => itemTest<ICountriesRepo, Country, CountryData>(
            obj.CountryID, d => new Country(d), () => obj.Country);
        [TestMethod] public void CurrencyTest() => itemTest<ICurrenciesRepo, Currency, CurrencyData>(
            obj.CurrencyID, d => new Currency(d), () => obj.Currency);
    }
}
