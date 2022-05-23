using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data;
using System;

namespace Rakendus.Tests.Data {
    [TestClass] public class PersonDataTests : AbstractClassTests<PersonData, UniqueData>{
        private class testClass: PersonData { }
        protected override PersonData createObj() => new testClass();
        [TestMethod] public void FirstNameTest() => isProperty<string>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
    }
}
