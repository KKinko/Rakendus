using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface IItemsRepo : IRepo<Item> { }
    public sealed class Item: Entity<ItemData>
    {
        public Item() : this(new ItemData()) { }
        public Item(ItemData d) : base(d) { }
        
        public string? Isbn => getValue(Data?.Isbn);
        public string? Libary => getValue(Data?.Libary); 

        
        
    }
}
