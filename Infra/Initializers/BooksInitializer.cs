using Rakendus.Data.Party;

namespace Rakendus.Infra.Initializers
{
    public sealed class BooksInitializer: BaseInitializer<BookData>
    {
        public BooksInitializer(RakendusDb? db) : base(db, db?.Books) { }
        internal static BookData createBook(string isbn, string title, string field, DateTime publishDate, int pageCount)
        {
            var book = new BookData
            {
                ID = isbn,
                Title = title,
                Field = field,
                PublishDate = publishDate,
                PageCount = pageCount

            };
            return book;
        }
        protected override IEnumerable<BookData> getEntities => new[] {
            createBook("0-316-16017-2", "Twilight", "Fantasy", new DateTime(2005, 08, 05), 498),
            createBook("0-618-32970-6", "Extremely Loud & Incredibly Close", "Novel",  new DateTime(2005, 04, 01), 368),
            createBook("978-1-59463-449-9", "Matrix", "Historical novel" , new DateTime(2021, 07, 01), 513),
            createBook("978-0374275631", "Thinking, Fast and Slow", "Psychology" , new DateTime(1980, 03, 01), 513),
            createBook("0-345-40946-9", "The Demon-Haunted World", "Science" , new DateTime(1995, 04, 01), 457),
            createBook("978-91-1-301408-1", "The Girl with the Dragon Tattoo", "Crime" , new DateTime(2005, 08, 01), 433),
            createBook("978-0307588364", "Gone Girl", "Thriller" , new DateTime(2012, 03, 01), 513)

        };
    }


}
