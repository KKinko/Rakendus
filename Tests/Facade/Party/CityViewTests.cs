using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class CityViewTests: SealedClassTests<CityView, UniqueView>
    {
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void CountyTest() => isProperty<string?>();
        [TestMethod] public void CountryIDTest() => isProperty<string?>();
        
    }
}
