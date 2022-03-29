using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;

namespace Rakendus.Tests.Facade
{
    [TestClass]
    public class BaseViewTests : AbstractClassTests
    {
        private class testClass : BaseView { }
        protected override object createObj() => new testClass();

    }
}
