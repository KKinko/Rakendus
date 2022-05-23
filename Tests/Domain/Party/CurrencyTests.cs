using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party {
    [TestClass] public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>>  {
        protected override Currency createObj() => new(GetRandom.Value<CurrencyData>());
        [TestMethod] public void CountryCurrenciesTest()
            => itemsTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(
                d => d.CurrencyID = obj.ID, d => new CountryCurrency(d), () => obj.CountryCurrencies.Value);
      
        [TestMethod]
        public void CountriesTest() => relatedItemsTest<ICountriesRepo, CountryCurrency, Country, CountryData>
            (CountryCurrenciesTest, () => obj.CountryCurrencies.Value, () => obj.Countries.Value,
              x => x.CountryID, d => new Country(d), c => c?.Data, x => x?.Country?.Data);
    }
}
