using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;
using System;

namespace Rakendus.Tests.Facade {
    [TestClass] public class PersonViewTests : AbstractClassTests<PersonView, UniqueView> {
        private class testClass : PersonView { }
        protected override PersonView createObj() => new testClass();
        [TestMethod] public void FirstNameTest() => isDisplayNamed<string?>("Firstname");
        [TestMethod] public void LastNameTest() => isDisplayNamed<string?>("Lastname");
        [TestMethod] public void DoBTest() => isDisplayNamed<DateTime?>("Date Of Birth");
    }
}
