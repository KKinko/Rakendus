using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data;
using Rakendus.Data.Party;
using System;

namespace Rakendus.Tests.Data.Party
{
    [TestClass] public class LoanedDataTests: SealedClassTests<LoanedData, UniqueData>
    {
        [TestMethod] public void ItemIDTest() => isProperty<string>();
        [TestMethod] public void ReaderIDTest() => isProperty<string?>();
        [TestMethod] public void LoanedDateTest() => isProperty<DateTime?>();
        [TestMethod] public void LoanedReturnedTest() => isProperty<DateTime?>();
    }
}
