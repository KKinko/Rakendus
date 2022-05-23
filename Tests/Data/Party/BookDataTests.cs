using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data;
using Rakendus.Data.Party;
using System;

namespace Rakendus.Tests.Data.Party
{
    [TestClass] public class BookDataTests: SealedClassTests<BookData, UniqueData>
    {
        [TestMethod] public void IsbnTest() => isProperty<string?>();
        [TestMethod] public void TitleTest() => isProperty<string?>();
        [TestMethod] public void FieldTest() => isProperty<string?>();
        [TestMethod] public void PublishDateTest() => isProperty<DateTime?>();
        [TestMethod] public void PageCountTest() => isProperty<int?>();
    }
}
