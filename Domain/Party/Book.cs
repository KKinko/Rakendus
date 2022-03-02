using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public class Book: Entity<BookData>
    {
        private const string defaultStr = "Undefined";
        private const int defaultInt = 0;

        private DateTime defaultDate => DateTime.MinValue;
        public Book() : this(new BookData()) { }
        public Book (BookData d) : base(d) { }
        public string IsbnID => Data?.IsbnID ?? defaultStr;
        public string Title => Data?.Title ?? defaultStr;
        public string Author => Data?.Author ?? defaultStr;
        public string Field => Data?.Field ?? defaultStr;
        public DateTime PublishDate => Data?.PublishDate ?? defaultDate;
        public int PageCount => Data?.PageCount ?? defaultInt;
        public override string ToString() => $"{Title} {Author} ({Field}, {PublishDate}, {PageCount})";
    }
}
