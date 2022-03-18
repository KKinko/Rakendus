using System.ComponentModel.DataAnnotations;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Facade.Party
{
    public sealed class BookView: BaseView
    {
        [Display(Name = "Title")] public string? Title { get; set; }
        [Display(Name = "Author")]  public string? Author { get; set; }
        [Display(Name = "Field")]  public string? Field { get; set; }
        [Display(Name = "Publish date")] public DateTime? PublishDate { get; set; }
        [Display(Name = "Pages")] public int? PageCount { get; set; }
        [Display(Name = "Book")] public string? FullBookName { get; set; }

    }
    public sealed class BookViewFactory : BaseViewFactory<BookView, Book, BookData>
    {
        protected override Book toEntity(BookData d) => new(d);
        public override BookView Create(Book? e)
        {
            var v = base.Create(e);
            v.FullBookName = e?.ToString();
            return v;
        }
    }
}
