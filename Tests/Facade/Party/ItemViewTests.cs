using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class ItemViewTests : SealedClassTests<ItemView>
    {
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void InStockTest() => isProperty<int?>();
        [TestMethod] public void LibaryTest() => isProperty<string?>();
        
    }
}
