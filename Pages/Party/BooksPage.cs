using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages
{
    public class BooksPage : BasePage<BookView, Book, IBooksRepo>
    {
        public BooksPage(IBooksRepo r) : base(r) { }

        protected override Book toObject(BookView? item) => new BookViewFactory().Create(item);

        protected override BookView toView(Book? entity) => new BookViewFactory().Create(entity);
    }
}

