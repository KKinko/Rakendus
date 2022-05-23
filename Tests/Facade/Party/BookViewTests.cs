using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class BookViewTests: SealedClassTests<BookView, UniqueView>
    {
        [TestMethod] public void TitleTest() => isDisplayNamed<string?>("Title");
        [TestMethod] public void IsbnTest() => isDisplayNamed<string?>("Isbn");
        [TestMethod] public void FieldTest() => isDisplayNamed<string?>("Field");
        [TestMethod] public void PublishDateTest() => isDisplayNamed<DateTime?>("Publish date");
        [TestMethod] public void PageCountTest() => isDisplayNamed<int?>("Pages");

    }
}