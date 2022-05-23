using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class CountryCurrencyViewTests : SealedClassTests<CountryCurrencyView, NamedView>
    {
        [TestMethod] public void CountryIDTest() => isRequired<string>("Country");
        [TestMethod] public void CurrencyIDTest() => isRequired<string>("Currency");
        [TestMethod] public void CodeTest() => isDisplayNamed<string?>("Currency Native Code");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Currency Native Name");
    }
}
