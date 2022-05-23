using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;

namespace Rakendus.Tests.Facade
{
    [TestClass]
    public class IsoNamedViewTests : AbstractClassTests<IsoNamedView, NamedView>
    {
        private class testClass : IsoNamedView { }
        protected override IsoNamedView createObj() => new testClass();
        [TestMethod] public void CodeTest() => isDisplayNamed<string>("ISO Three-Letter Code");
        [TestMethod] public void NameTest() => isDisplayNamed<string>("English Name");
        [TestMethod] public void DescriptionTest() => isDisplayNamed<string>("Native name");

    }
}
