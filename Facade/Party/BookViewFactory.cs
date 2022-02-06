using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Facade.Party
{
    public class BookViewFactory
    {
        public Book Create(BookView v) => new(new BookData
        {
            IsbnID = v.IsbnID,
            Title = v.Title,
            Author = v.Author,
            Field = v.Field,
            PublishDate = v.PublishDate,
            PageCount = v.PageCount
        });
        public BookView Create(Book o) => new()
        {
            IsbnID = o.IsbnID,
            Title = o.Title,
            Author = o.Author,
            Field = o.Field,
            PublishDate = o.PublishDate,
            PageCount = o.PageCount,
            FullBookName = o.ToString()
        };

    }
}

