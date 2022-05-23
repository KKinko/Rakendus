using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party {
    [TestClass] public class ItemTests : SealedClassTests<Item, UniqueEntity<ItemData>> {
        protected override Item createObj() => new(GetRandom.Value<ItemData>());
        [TestMethod] public void BookIDTest() => isReadOnly(obj.Data.BookID);
        [TestMethod] public void LibaryIDTest() => isReadOnly(obj.Data.LibaryID);
    }
}
