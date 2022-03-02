using Microsoft.EntityFrameworkCore;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public class BooksRepo : Repo<Book, BookData>, IBooksRepo
    {
        public BooksRepo(DbContext c, DbSet<BookData> s) : base(c, s) { }

        protected override Book toDomain(BookData d) => new Book(d);
    }
}
