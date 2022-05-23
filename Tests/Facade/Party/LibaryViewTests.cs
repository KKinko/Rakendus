using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class LibaryViewTests: SealedClassTests<LibaryView, UniqueView>
    {
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Name");
        [TestMethod] public void AddressTest() => isDisplayNamed<string?>("Address");
        [TestMethod] public void CityIDTest() => isDisplayNamed<string?>("City");
        
    }
}