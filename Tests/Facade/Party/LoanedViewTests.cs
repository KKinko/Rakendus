using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class LoanedViewTests : SealedClassTests<LoanedView, UniqueView>
    {
        [TestMethod] public void ItemIDTest() => isProperty<string?>();
        [TestMethod] public void ReaderIDTest() => isProperty<string?>();
        [TestMethod] public void LoanedDateTest() => isProperty<DateTime?> ();
        [TestMethod] public void LoanedReturnedTest() => isProperty<DateTime?>();
    }
}
