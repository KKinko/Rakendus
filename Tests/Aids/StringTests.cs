using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;

namespace Rakendus.Tests.Aids
{
    [TestClass] public class StringTests : TypeTests
    {
        private string? testStr;
        [TestInitialize] public void Init() => testStr = "a2b2c2.d2e2f2.g2h2i2";
        [TestMethod] public void RemoveTest() => areEqual("abc.def.ghi", Strings.Remove(testStr, "2"));
        [TestMethod]
        public void IsTypeNameTest()
        {
            isFalse(Strings.IsTypeName(testStr));
            var s = Strings.Remove(testStr, "2");
            isFalse(Strings.IsTypeName(s));
            s = Strings.RemoveTail(s);
            isFalse(Strings.IsTypeName(s));
            s = Strings.RemoveTail(s);
            isTrue(Strings.IsTypeName(s));
        }
        [TestMethod]
        public void IsTypeFullNameTest()
        {
            isTrue(Strings.IsTypeFullName(testStr));
            isTrue(Strings.IsTypeFullName(Strings.Remove(testStr, "2")));
        }
        [TestMethod] public void RemoveTailTest() => areEqual("a2b2c2.d2e2f2", Strings.RemoveTail(testStr));
        [TestMethod] public void RemoveHeadTest() => areEqual("d2e2f2.g2h2i2", Strings.RemoveHead(testStr));
    }
}
