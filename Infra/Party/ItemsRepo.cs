using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public class ItemsRepo : Repo<Item, ItemData>, IItemsRepo
    {
        public ItemsRepo(RakendusDb? db) : base(db, db?.Items) { }
        protected override Item toDomain(ItemData d) => new Item(d);
    }
}
