using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using System;

namespace Rakendus.Tests.Data.Party
{
    [TestClass] public class BookDataTests: BaseTestss<BookData>
    {
        [TestMethod] public void IsbnIDTest() => isProperty<string>();
        [TestMethod] public void TitleTest() => isProperty<string?>();
        [TestMethod] public void AuthorTest() => isProperty<string?>();
        [TestMethod] public void FieldTest() => isProperty<string?>();
        [TestMethod] public void PublishDateTest() => isProperty<DateTime?>();
        [TestMethod] public void PageCountTest() => isProperty<int?>();
    }
}
