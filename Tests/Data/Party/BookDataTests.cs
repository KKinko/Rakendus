using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using System;

namespace Rakendus.Tests.Data.Party
{
    [TestClass] public class BookDataTests: SealedClassTests<BookData>
    {
        [TestMethod] public void IDTest() => isProperty<string>();
        [TestMethod] public void TitleTest() => isProperty<string?>();
        [TestMethod] public void AuthorTest() => isProperty<string?>();
        [TestMethod] public void FieldTest() => isProperty<string?>();
        [TestMethod] public void PublishDateTest() => isProperty<DateTime?>();
        [TestMethod] public void PageCountTest() => isProperty<int?>();
    }
}
