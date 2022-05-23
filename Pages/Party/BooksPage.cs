using Microsoft.AspNetCore.Authorization;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    [Authorize]
    public class BooksPage : PagedPage<BookView, Book, IBooksRepo>
    {
        public BooksPage(IBooksRepo r) : base(r) { }

        protected override Book toObject(BookView? item) => new BookViewFactory().Create(item);

        protected override BookView toView(Book? entity) => new BookViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(BookView.ID),
            nameof(BookView.Title),
            nameof(BookView.Field),
            nameof(BookView.PublishDate),
            nameof(BookView.PageCount)
        };
        public Lazy<List<Author?>> Authors => toObject(Item).Authors;
    }
}

