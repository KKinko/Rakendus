using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface IBooksAuthorsRepo : IRepo<BookAuthor> { }
    public sealed class BookAuthor : UniqueEntity<BookAuthorData>
    {
        public BookAuthor() : this(new ()) { }
        public BookAuthor(BookAuthorData d) : base(d) { }
        public string BookID => getValue(Data?.BookID);
        public string AuthorID => getValue(Data?.AuthorID);
        public Book? Book => GetRepo.Instance<IBooksRepo>()?.Get(BookID);
        public Author? Author => GetRepo.Instance<IAuthorsRepo>()?.Get(AuthorID);
    }


}

