using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade
{
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests
    {
        private class testClass : BaseViewFactory<BookView, Book, BookData>
        {
            protected override Book toEntity(BookData d) => new Book(d);
        }
        protected override object createObj() => new testClass();
    }
}
