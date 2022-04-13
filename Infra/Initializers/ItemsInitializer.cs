using Rakendus.Data.Party;

namespace Rakendus.Infra.Initializers
{
    public sealed class ItemsInitializer : BaseInitializer<ItemData>
    {
        public ItemsInitializer(RakendusDb? db) : base(db, db?.Items) { }
        internal static ItemData createItem(string id, string isbn, string libaryName)
        {
            var item = new ItemData
            {
                ID = id,
                Isbn = isbn,
                Libary = libaryName

            };
            return item;
        }
        protected override IEnumerable<ItemData> getEntities => new[] {
            createItem("1223", "122", "Tartu Ülikooli Raamatukogu"),
            createItem("123331", "122", "Tartu Ülikooli Raamatukogu"),
            createItem("123123", "1", "Annelinna raamatukogu"),
            createItem("12312321", "3", "Annelinna raamatukogu")
        };
    }
}
