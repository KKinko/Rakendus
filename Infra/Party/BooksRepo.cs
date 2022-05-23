using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class BooksRepo : Repo<Book, BookData>, IBooksRepo
    {
        public BooksRepo(RakendusDb? db) : base(db, db?.Books) { }
        protected internal override Book toDomain(BookData d) => new(d);

        internal override IQueryable<BookData> addFilter(IQueryable<BookData> q)
        {
            var y = CurrentFilter;
           return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
               x => x.Title.Contains(y)
                || x.Isbn.Contains(y)
                || x.ID.Contains(y)
                || x.Field.Contains(y)
                || x.PublishDate.ToString().Contains(y)
                || x.PageCount.ToString().Contains(y));
        }
    }
}
