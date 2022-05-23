using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class BookAuthorViewFactoryTests: ViewFactoryTests<BookAuthorViewFactory, BookAuthorView, BookAuthor, BookAuthorData>
    {

        protected override BookAuthor toObject(BookAuthorData d) => new(d);
    }
}