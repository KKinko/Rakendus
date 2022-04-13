using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass]
    public class ReaderViewFactoryTests : SealedClassTests<Rakendus.Facade.Party.ReaderViewFactory>
    {
        [TestMethod] public void CreateTestForReader() { }
        [TestMethod] public void CreateViewTestForReader()
        {
            var d = GetRandom.Value<ReaderData>();
            var e = new Reader(d);
            var v = new Rakendus.Facade.Party.ReaderViewFactory().Create(e);
            isNotNull(v);
            //TODO mõtelge
            //arePropertiesEaqual(v, e, nameof(v.FullName));
            areEqual(v.ID, e.ID);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.Gender, e.Gender);
            areEqual(v.DoB, e.DoB);
            areEqual(v.Telephone, e.Telephone);
            areEqual(v.City, e.City);
            areEqual(v.HomeAddress, e.HomeAddress);
            areEqual(v.Education, e.Education);
            areEqual(v.EmailAddress, e.EmailAddress);
        }
        [TestMethod] public void CreateEntityTestForReader()
        {
            var v = GetRandom.Value<ReaderView>();
            var e = new Rakendus.Facade.Party.ReaderViewFactory().Create(v);
            isNotNull(e);
            //TODO mõtelge
            //arePropertiesEaqual(e, v);
            areEqual(v.ID, v.ID);
            areEqual(v.FirstName, v.FirstName);
            areEqual(v.LastName, v.LastName);
            areEqual(v.Gender, v.Gender);
            areEqual(v.DoB, v.DoB);
            areEqual(v.Telephone, v.Telephone);
            areEqual(v.City, v.City);
            areEqual(v.HomeAddress, v.HomeAddress);
            areEqual(v.Education, v.Education);
            areEqual(v.EmailAddress, v.EmailAddress);
        }
    }
}
