using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface IBooksRepo : IRepo<Book> { }
    public sealed class Book: Entity<BookData>
    {
        public Book() : this(new BookData()) { }
        public Book (BookData d) : base(d) { }

        public string Title => getValue(Data?.Title);
        public string Author => getValue(Data?.Author);
        public string Field => getValue(Data?.Field);
        public DateTime PublishDate => getValue(Data?.PublishDate);
        public int PageCount => getValue(Data?.PageCount);
        public override string ToString() => $"{Title} {Author} ({Field}, {PublishDate}, {PageCount})";
    }
}
