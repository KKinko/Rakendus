using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Facade;
using Rakendus.Facade.Party;
using Rakendus.Tests.Data.Party;
using System;


namespace Rakendus.Tests.Facade.Party
{
    [TestClass]
    public class ReaderViewTests: SealedClassTests<ReaderView, PersonView>
    {
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void TelephoneTest() => isProperty<int?>();
        [TestMethod] public void CityIDTest() => isProperty<string?>();
        [TestMethod] public void HomeAddressTest() => isProperty<string?>();
        [TestMethod] public void ReaderFullNameTest() => isProperty<string?>();
    }
}
