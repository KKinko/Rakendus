using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    public class AuthorsPage : PagedPage<AuthorView, Author, IAuthorsRepo>
    {
        public AuthorsPage(IAuthorsRepo r) : base(r) { }

        protected override Author toObject(AuthorView? item) => new AuthorViewFactory().Create(item);

        protected override AuthorView toView(Author? entity) => new AuthorViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(AuthorView.ID),
            nameof(AuthorView.FirstName),
            nameof(AuthorView.LastName),
            nameof(AuthorView.DoB)
        };
        public Lazy<List<Book?>> Books => toObject(Item).Books;
    }
}

