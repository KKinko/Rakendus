using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party
{
    [TestClass] public class LibaryTests : SealedClassTests<Libary, UniqueEntity<LibaryData>> {
        protected override Libary createObj() => new(GetRandom.Value<LibaryData>());
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void AddressTest() => isReadOnly(obj.Data.Address);
        [TestMethod] public void CityIDTest() => isReadOnly(obj.Data.CityID);
    }
}
