using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;
using Rakendus.Infra.Party;

namespace Rakendus.Tests.Infra.Party
{
    [TestClass]
    public class ItemsRepoTests : SealedRepoTests<ItemsRepo, Repo<Item, ItemData>, Item, ItemData>
    {
        protected override ItemsRepo createObj() => new(GetRepo.Instance<RakendusDb>());
        protected override object? getSet(RakendusDb db) => db.Items;
    }
}
