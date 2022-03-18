using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class LoanedViewTests : SealedClassTests<LoanedView>
    {
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void LoanedDateTest() => isProperty<DateTime?> ();
        [TestMethod] public void LoanedDueTest() => isProperty<DateTime?> ();
        [TestMethod] public void LoanedReturnedTest() => isProperty<DateTime?>();
        [TestMethod] public void OverdueFineTest() => isProperty<int?>();
        [TestMethod] public void LoanedStatusTest() => isProperty<bool?>();
    }
}
