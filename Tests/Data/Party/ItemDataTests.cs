using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data;
using Rakendus.Data.Party;

namespace Rakendus.Tests.Data.Party
{
    [TestClass] public class ItemDataTests: SealedClassTests<ItemData, UniqueData>
    {
        [TestMethod] public void BookIDTest() => isProperty<string>();
        [TestMethod] public void LibaryIDTest() => isProperty<string?>();
    }
}
