using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public class Book
    {
        private const string defaultStr = "Undefined";
        private const int defaultInt = 0;

        private DateTime defaultDate => DateTime.MinValue;
        private BookData data;

        public Book() : this(new BookData()) { }
        public Book(BookData d) => data = d;


        public string IsbnID => data?.IsbnID ?? defaultStr;
        public string Title => data?.Title ?? defaultStr;
        public string Author => data?.Author ?? defaultStr;
        public string Field => data?.Field ?? defaultStr;
        public DateTime PublishDate => data?.PublishDate ?? defaultDate;
        public int PageCount => data?.PageCount ?? defaultInt;
        public BookData Data => data;
        public override string ToString() => $"{Title} {Author} ({Field}, {PublishDate}, {PageCount})";
    }
}
