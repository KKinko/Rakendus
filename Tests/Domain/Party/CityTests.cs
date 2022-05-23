using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party {
    [TestClass] public class CityTests : SealedClassTests<City, UniqueEntity<CityData>> {
        protected override City createObj() => new(GetRandom.Value<CityData>());
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void CountyTest() => isReadOnly(obj.Data.County);
        [TestMethod] public void CountryIDTest() => isReadOnly(obj.Data.CountryID);
    }
}
