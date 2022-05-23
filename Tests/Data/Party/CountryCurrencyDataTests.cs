
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data;
using Rakendus.Data.Party;

namespace Rakendus.Tests.Data.Party {
    [TestClass] public class CountryCurrencyDataTests : SealedClassTests<CountryCurrencyData, NamedData> {
        [TestMethod] public void CountryIDTest() => isProperty<string>();
        [TestMethod] public void CurrencyIDTest() => isProperty<string>();
    }
}
