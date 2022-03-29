using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Rakendus.Aids;
using Rakendus.Data.Party;

namespace Rakendus.Tests.Data.Party
{
    [TestClass]
    public class ReaderDataTests: SealedClassTests<ReaderData> {
        [TestMethod] public void IDTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<bool?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
        [TestMethod] public void TelephoneTest() => isProperty<int?>();
        [TestMethod] public void CityTest() => isProperty<string?>();
        [TestMethod] public void HomeAddressTest() => isProperty<string?>();
        [TestMethod] public void EducationTest() => isProperty<string?>();
        [TestMethod] public void EmailAddressTest() => isProperty<string?>();
    }
}
