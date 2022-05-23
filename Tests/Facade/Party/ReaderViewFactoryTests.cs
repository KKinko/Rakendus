using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass]
    public class ReaderViewFactoryTests: SealedClassTests<ReaderViewFactory, BaseViewFactory<ReaderView, Reader, ReaderData>> {
        [TestMethod] public void CreateTest() { }
    [TestMethod]
    public void CreateViewTest()
    {
        var d = GetRandom.Value<ReaderData>();
        var e = new Reader(d);
        var v = new ReaderViewFactory().Create(e);
        isNotNull(v);
        areEqual(v.DoB, e.DoB);
        areEqual(v.ID, e.ID);
        areEqual(v.Gender, e.Gender);
        areEqual(v.FirstName, e.FirstName);
        areEqual(v.LastName, e.LastName);
        areEqual(v.ReaderFullName, e.ToString());
    }
    [TestMethod]
    public void CreateEntityTest()
    {
        var v = GetRandom.Value<ReaderView>() as ReaderView;
        var e = new ReaderViewFactory().Create(v);
        isNotNull(e);
        isNotNull(v);
        arePropertiesEqual(e, v);
        areNotEqual(e.ToString(), v.ReaderFullName);
    }

}
}
