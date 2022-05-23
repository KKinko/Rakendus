using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data;
using Rakendus.Data.Party;
using System;

namespace Rakendus.Tests.Data.Party
{
    [TestClass] public class LibaryDataTests: SealedClassTests<LibaryData, UniqueData>
    {
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void AddressTest() => isProperty<string?>();
        [TestMethod] public void CityIDTest() => isProperty<string?>();
    }
}
