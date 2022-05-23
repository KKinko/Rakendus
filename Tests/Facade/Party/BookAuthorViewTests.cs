using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Facade;
using Rakendus.Facade.Party;
using System;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class BookAuthorViewTests: SealedClassTests<BookAuthorView, UniqueView>
    {
        [TestMethod] public void BookIDTest() => isProperty<string?>();
        [TestMethod] public void AuthorIDTest() => isProperty<string?>();
        
    }
}
