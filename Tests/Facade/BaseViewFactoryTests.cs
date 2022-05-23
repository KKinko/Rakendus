using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade {
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<BookView, Book, BookData>, object> {
        private class testClass : BaseViewFactory<BookView, Book, BookData> {
            protected override Book toEntity(BookData d) => new(d);
        }
        protected override BaseViewFactory<BookView, Book, BookData> createObj() => new testClass();

        [TestMethod] public void CreateTest() {}
        [TestMethod] public void CreateViewTest() {
            var v = GetRandom.Value<BookView>();
            var o = obj.Create(v);
            areEqualProperties(v, o.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            var d = GetRandom.Value<BookData>();
            var v = obj.Create(new Book(d));
            areEqualProperties(d, v);
        }
    }
}
