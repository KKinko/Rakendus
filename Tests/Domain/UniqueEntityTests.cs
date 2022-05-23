using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;

namespace Rakendus.Tests.Domain {
    [TestClass]  public class UniqueEntityTests : AbstractClassTests<UniqueEntity<CountryData>, UniqueEntity > {
        private CountryData? d;
        private class testClass : UniqueEntity<CountryData> { 
            public testClass() : this(new CountryData()) { }
            public testClass(CountryData d) : base(d) { }
        }
        protected override UniqueEntity<CountryData> createObj() {
            d = GetRandom.Value<CountryData>();
            return new testClass(d);
        }
        [TestMethod] public void IDTest() => isReadOnly(obj.Data.ID);
        [TestMethod] public void DataTest() => isReadOnly(d);
        [TestMethod] public void DefaultStrTest() => areEqual("Undefined", UniqueEntity.defaultStr);
    }
}
