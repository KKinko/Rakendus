using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party {
    [TestClass] public class ReaderTests : SealedClassTests<Reader, PersonEntity<ReaderData>> {
        protected override Reader createObj() => new(GetRandom.Value<ReaderData>());
        [TestMethod] public void TelephoneTest() => isReadOnly(obj.Data.Telephone);
        [TestMethod] public void CityIDTest() => isReadOnly(obj.Data.CityID);
        [TestMethod] public void GenderTest() => isReadOnly(obj.Data.Gender);
        [TestMethod] public void HomeAddressTest() => isReadOnly(obj.Data.HomeAddress);
        [TestMethod] public void LoanedIDTest() => isReadOnly(obj.Data.LoanedID);
        [TestMethod] public void ToStringTest()  {
            var expected = $"{obj.FirstName} {obj.LastName} ({obj.Gender.Description()}, {obj.DoB})";
            areEqual(expected, obj.ToString());
        }
    }
}
