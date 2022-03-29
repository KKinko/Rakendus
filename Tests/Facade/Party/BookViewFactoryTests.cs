using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class BookViewFactoryTests: SealedClassTests<BookViewFactory>
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest()
        {
            var d = GetRandom.Value<BookData>();
            var e = new Book(d);
            var v = new BookViewFactory().Create(e);
            isNotNull(v);
            //TODO mõtelge
            //arePropertiesEaqual(v, e, nameof(v.FullName));
            areEqual(v.ID, e.ID);
            areEqual(v.Title, e.Title);
            areEqual(v.Author, e.Author);
            areEqual(v.Field, e.Field);
            areEqual(v.PublishDate, e.PublishDate);
            areEqual(v.PageCount, e.PageCount);
            areEqual(v.FullBookName, e.ToString());
        }
        [TestMethod] public void CreateEntityTest()
        {
            var v = GetRandom.Value<BookView>();
            var e = new BookViewFactory().Create(v);
            isNotNull(e);
            //TODO mõtelge
            //arePropertiesEaqual(e, v);
            areEqual(e.ID, v.ID);
            areEqual(e.Title, v.Title);
            areEqual(e.Author, v.Author);
            areEqual(e.Field, v.Field);
            areEqual(e.PublishDate, v.PublishDate);
            areEqual(e.PageCount, v.PageCount);
            areNotEqual(e.ToString(), v.FullBookName);
        }
    }
}