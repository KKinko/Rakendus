using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;

namespace Rakendus.Tests.Aids
{
    [TestClass] public class GetNamespaceTests : TypeTests 
    {
        [TestMethod]
        public void OfTypeTest()
        {
            var obj = new ReaderData();
            var name = obj.GetType().Namespace;
            var n = GetNamespace.OfType(obj);
            areEqual(name, n);
        }
        [TestMethod]
        public void OfTypeNullTest()
        {
            ReaderData? obj = null;
            var n = GetNamespace.OfType(obj);
            areEqual(string.Empty, n);
        }
    }
}
