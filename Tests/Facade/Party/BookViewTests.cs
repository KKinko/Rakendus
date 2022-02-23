using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class BookViewTests: BaseTests<BookView>
    {
        [TestMethod] public void IsbnIDTest() => isProperty<string>();
        [TestMethod] public void TitleTest() => isProperty<string>();
        [TestMethod] public void AuthorTest() => isProperty<string>();
        [TestMethod] public void FieldTest() => isProperty<string>();
        [TestMethod] public void PublishDateTest() => isProperty<DateTime?>();
        [TestMethod] public void PageCounTest() => isProperty<int>();
        [TestMethod] public void FullBookNameTest() => isProperty<string>();
        
    }
}
