using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class AuthorViewFactoryTests : ViewFactoryTests<BookViewFactory, BookView, Book, BookData>
    {
        protected override Book toObject(BookData d) => new(d);
    } 
}