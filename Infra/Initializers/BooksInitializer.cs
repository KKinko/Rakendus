using Rakendus.Data.Party;

namespace Rakendus.Infra.Initializers
{
    public sealed class BooksInitializer: BaseInitializer<BookData>
    {
        public BooksInitializer(RakendusDb? db) : base(db, db?.Books) { }
        internal static BookData createBook(string isbn, string title, string name, string field, DateTime publishDate, int pageCount)
        {
            var book = new BookData
            {
                ID = isbn,
                Title = title,
                Author = name,
                Field = field,
                PublishDate = publishDate,
                PageCount = pageCount

            };
            return book;
        }
        protected override IEnumerable<BookData> getEntities => new[] {
            createBook("123123123", "Clean Code", "Kaspar Sukk", "IT", new DateTime(1980, 07, 31), 432),
            createBook("12312312312", "Cosmos", "Joonas Nukk","Science",  new DateTime(1979, 09, 19), 523),
            createBook("1412411231221", "The Guns of August", "Mari Aas", "History" , new DateTime(1980, 03, 01), 513)
        };
    }


}
