using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;

namespace Rakendus.Tests.Aids
{
    [TestClass] public class EnumsTests : TypeTests {
       [TestMethod] public void DescriptionTest()
            => areEqual("Not applicable", Enums.Description(IsoGender.NotApplicable));
       [TestMethod] public void ToStringTest()
             => areEqual("NotApplicable", IsoGender.NotApplicable.ToString());
    }
}
