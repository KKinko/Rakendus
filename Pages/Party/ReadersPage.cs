using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages
{
    public class ReadersPage : BasePage<ReaderView, Reader, IReadersRepo>
    {
        public ReadersPage(IReadersRepo r) : base(r) { }

        protected override Reader toObject(ReaderView? item) => new Facade.Party.ReaderViewFactory().Create(item);

        protected override ReaderView toView(Reader? entity) => new Facade.Party.ReaderViewFactory().Create(entity);
    }
}
