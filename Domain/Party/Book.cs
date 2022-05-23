using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface IBooksRepo : IRepo<Book> { }
    public sealed class Book: UniqueEntity<BookData>
    {
        public Book() : this(new ()) { }
        public Book (BookData d) : base(d) { }

        public string? Isbn => getValue(Data?.Isbn);
        public string Title => getValue(Data?.Title);
        public string Field => getValue(Data?.Field);
        public DateTime PublishDate => getValue(Data?.PublishDate);
        public int PageCount => getValue(Data?.PageCount);
         public Lazy<List<BookAuthor>> BooksAuthors
        {
            get
            {
                var l = GetRepo.Instance<IBooksAuthorsRepo>()?
                   .GetAll(x => x.BookID)?
                   .Where(x => x.BookID == ID)?
                   .ToList() ?? new List<BookAuthor>();
                return new Lazy<List<BookAuthor>>(l);
            }
        }
        public Lazy<List<Author?>> Authors
        {
            get
            {
                var l = BooksAuthors.Value
                  .Select(x => x.Author)
                  .ToList() ?? new List<Author?>();
                return new Lazy<List<Author?>>(l);
            }
        }
        public int CompareTo(object? x) => compareTo(x as Book);
        private int compareTo(Book? c) => Field.CompareTo(c?.Field);
    }
}
