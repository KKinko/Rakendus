using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface IAuthorsRepo : IRepo<Author> { }
    public sealed class Author : PersonEntity<AuthorData>
    {
        public Author() : this(new()) { }
        public Author(AuthorData d) : base(d) { }
        public Lazy<List<BookAuthor>> BooksAuthors
        {
            get
            {
                var l = GetRepo.Instance<IBooksAuthorsRepo>()?
                   .GetAll(x => x.AuthorID)?
                   .Where(x => x.AuthorID == ID)?
                   .ToList() ?? new List<BookAuthor>();
                return new Lazy<List<BookAuthor>>(l);
            }
        }
        public Lazy<List<Book?>> Books
        {
            get
            {
                var l = BooksAuthors.Value
                  .Select(x => x.Book)
                  .ToList() ?? new List<Book?>();
                return new Lazy<List<Book?>>(l);

            }


        }
    }
}

