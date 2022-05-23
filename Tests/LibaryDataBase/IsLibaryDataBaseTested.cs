using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rakendus.Tests.LibaryDatabase
{
    [TestClass] public class IsLibaryDataBaseTested: AssemblyTests
    {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"Rakendus.LibaryDataBase\"");
    }
}
