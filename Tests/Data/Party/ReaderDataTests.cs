using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Rakendus.Data.Party;
using Rakendus.Data;

namespace Rakendus.Tests.Data.Party
{
    [TestClass]
    public class ReaderDataTests: SealedClassTests<ReaderData, PersonData> {
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void TelephoneTest() => isProperty<int?>();
        [TestMethod] public void CityIDTest() => isProperty<string?>();
        [TestMethod] public void HomeAddressTest() => isProperty<string?>();
        [TestMethod] public void LoanedIDTest() => isProperty<string?>();
    }
}
