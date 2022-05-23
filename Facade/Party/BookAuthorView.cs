using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel;

namespace Rakendus.Facade.Party
{
    public sealed class BookAuthorView : UniqueView
    {
        [DisplayName("Book")] public string BookID { get; set; } = string.Empty;
        [DisplayName("Author")] public string AuthorID { get; set; } = string.Empty;
    }
    public sealed class BookAuthorViewFactory : 
        BaseViewFactory<BookAuthorView, BookAuthor, BookAuthorData>
    {
        protected override BookAuthor toEntity(BookAuthorData d) => new(d);
    }
}
