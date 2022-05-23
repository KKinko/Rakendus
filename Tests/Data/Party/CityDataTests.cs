using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data;
using Rakendus.Data.Party;

namespace Rakendus.Tests.Data.Party
{
    [TestClass] public class CityDataTests: SealedClassTests<CityData, UniqueData>
    {
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void CountyTest() => isProperty<string?>();
        [TestMethod] public void CountryIDTest() => isProperty<string?>();
    }
}
