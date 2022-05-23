using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    public class BooksAuthorsPage : PagedPage<BookAuthorView, BookAuthor, IBooksAuthorsRepo>
    {
        private readonly IBooksRepo books;
        private readonly IAuthorsRepo authors;
        public BooksAuthorsPage(IBooksAuthorsRepo r, IBooksRepo b, IAuthorsRepo a) : base(r) 
        {
            books = b;
            authors = a;

        }

        protected override BookAuthor toObject(BookAuthorView? item) => new BookAuthorViewFactory().Create(item);

        protected override BookAuthorView toView(BookAuthor? entity) => new BookAuthorViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(BookAuthorView.ID),
            nameof(BookAuthorView.AuthorID),
            nameof(BookAuthorView.BookID)
        };
        public IEnumerable<SelectListItem> Books
            => books?.GetAll(x => x.Isbn)?
            .Select(x => new SelectListItem(x.Isbn, x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Authors
            => authors?.GetAll(x => x.FirstName)?
            .Select(x => new SelectListItem(x.FirstName, x.ID))
            ?? new List<SelectListItem>();
        public string AuthorName(string? authorId = null)
            => Authors?.FirstOrDefault(x => x.Value == (authorId ?? string.Empty))?.Text ?? "Unspecified";
        public string BookName(string? bookId = null)
            => Books?.FirstOrDefault(x => x.Value == (bookId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, BookAuthorView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(BookAuthorView.AuthorID) ? AuthorName(r as string)
                : name == nameof(BookAuthorView.BookID) ? BookName(r as string)
                : r;
        }
    }
}

