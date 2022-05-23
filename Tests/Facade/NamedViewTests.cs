using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;

namespace Rakendus.Tests.Facade {
    [TestClass] public class NamedViewTests : AbstractClassTests<NamedView, UniqueView> {
        private class testClass : NamedView { }
        protected override NamedView createObj() => new testClass();
        [TestMethod] public void CodeTest() => isDisplayNamed<string?>("Code");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Name");
        [TestMethod] public void DescriptionTest() => isDisplayNamed<string?>("Description");
    }
}
