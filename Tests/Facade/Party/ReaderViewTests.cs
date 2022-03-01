using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Tests.Data.Party;
using System;


namespace Rakendus.Tests.Facade.Party
{
    [TestClass]
    public class ReaderViewTests: BaseTests<ReaderView>
    {
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
        [TestMethod] public void ReaderFullNameTest() => isProperty<string?>();
    }
}
