using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;

namespace Rakendus.Tests.Facade
{
    [TestClass] public class UniqueViewTests : AbstractClassTests<UniqueView, object> {
        private class testClass : UniqueView { }
        protected override UniqueView createObj() => new testClass();
        [TestMethod] public void IDTest() => isProperty<string>();
    }
}
