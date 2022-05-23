using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Facade.Party
{
    public sealed class BookView: UniqueView
    {
        [DisplayName("Isbn")] public string? Isbn { get; set; }
        [DisplayName("Title")] public string? Title { get; set; }
        [DisplayName("Field")]  public string? Field { get; set; }
        [DisplayName("Publish date")] public DateTime? PublishDate { get; set; }
        [DisplayName("Pages")] public int? PageCount { get; set; }

    }
    public sealed class BookViewFactory : BaseViewFactory<BookView, Book, BookData>
    {
        protected override Book toEntity(BookData d) => new(d);
    }
}
