using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class ItemsRepo : Repo<Item, ItemData>, IItemsRepo
    {
        public ItemsRepo(RakendusDb? db) : base(db, db?.Items) { }
        protected internal override Item toDomain(ItemData d) => new(d);
        internal override IQueryable<ItemData> addFilter(IQueryable<ItemData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
               x => x.BookID.Contains(y)
                || x.LibaryID.Contains(y)
                || x.ID.Contains(y));
        }
    }
}
