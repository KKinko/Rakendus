using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface IItemsRepo : IRepo<Item> { }
    public sealed class Item: UniqueEntity<ItemData>
    {
        public Item() : this(new ()) { }
        public Item(ItemData d) : base(d) { }
        
        public string BookID => getValue(Data?.BookID);
        public string LibaryID => getValue(Data?.LibaryID);

    }
}
