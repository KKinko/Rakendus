using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rakendus.Tests.Soft
{
    [TestClass] public class IsLibaryDataBaseTested: IsAssemblyTested
    {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"Rakendus.LibaryDataBase\"");
    }
}
