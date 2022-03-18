using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public class BooksRepo : Repo<Book, BookData>, IBooksRepo
    {
        public BooksRepo(RakendusDb? db) : base(db, db?.Books) { }
        protected override Book toDomain(BookData d) => new Book(d);
    }
}
