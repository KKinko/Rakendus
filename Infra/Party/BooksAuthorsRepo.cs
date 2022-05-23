using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class BooksAuthorsRepo : Repo<BookAuthor, BookAuthorData>, IBooksAuthorsRepo
    {
        public BooksAuthorsRepo(RakendusDb? db) : base(db, db?.BooksAuthors) { }
        protected internal override BookAuthor toDomain(BookAuthorData d) => new(d);
        internal override IQueryable<BookAuthorData> addFilter(IQueryable<BookAuthorData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
               x => x.BookID.Contains(y)
               || x.ID.Contains(y)
                || x.AuthorID.Contains(y));
        }
    }
}
