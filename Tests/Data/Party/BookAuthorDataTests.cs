using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data;
using Rakendus.Data.Party;
using System;

namespace Rakendus.Tests.Data.Party
{
    [TestClass] public class BookAuthorDataTests: SealedClassTests<BookAuthorData, UniqueData>
    {
        [TestMethod] public void BookIDTest() => isProperty<string?>();
        [TestMethod] public void AuthorIDTest() => isProperty<string?>();
    }
}
