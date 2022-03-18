using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class BookViewTests: SealedClassTests<BookView>
    {
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void TitleTest() => isProperty<string?>();
        [TestMethod] public void AuthorTest() => isProperty<string?>();
        [TestMethod] public void FieldTest() => isProperty<string?>();
        [TestMethod] public void PublishDateTest() => isProperty<DateTime?>();
        [TestMethod] public void PageCountTest() => isProperty<int?>();
        [TestMethod] public void FullBookNameTest() => isProperty<string?>();
        
    }
}
