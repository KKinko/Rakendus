using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;

namespace Rakendus.Tests.Domain {
    [TestClass] public class PersonEntityTests : AbstractClassTests<PersonEntity<ReaderData>, UniqueEntity<ReaderData>> {
        private class testClass : PersonEntity<ReaderData> {
            public testClass() : this(new ReaderData()) { }
            public testClass(ReaderData d) : base(d) { }
        }
        protected override PersonEntity<ReaderData> createObj() => new testClass(GetRandom.Value<ReaderData>());
        [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
        [TestMethod] public void DoBTest() => isReadOnly(obj.Data.DoB);
    }
}
