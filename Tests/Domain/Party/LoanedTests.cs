using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party {
    [TestClass] public class LoanedTests : SealedClassTests<Loaned, UniqueEntity<LoanedData>> {
        protected override Loaned createObj() => new(GetRandom.Value<LoanedData>());
        [TestMethod] public void ReaderIDTest() => isReadOnly(obj.Data.ReaderID);
        [TestMethod] public void ItemIDTest() => isReadOnly(obj.Data.ItemID);
        [TestMethod] public void LoanedDateTest() => isReadOnly(obj.Data.LoanedDate);
        [TestMethod] public void LoanedReturnedTest() => isReadOnly(obj.Data.LoanedReturned);
    }
}
