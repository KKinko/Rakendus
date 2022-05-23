using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class ItemViewTests : SealedClassTests<ItemView, UniqueView>
    {
        [TestMethod] public void BookIDTest() => isDisplayNamed<string?>("Isbn");
        [TestMethod] public void LibaryIDTest() => isDisplayNamed<string?>("Libary");

    }
}