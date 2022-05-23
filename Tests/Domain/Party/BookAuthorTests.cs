using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party { 
    [TestClass] public class BookAuthorTests : SealedClassTests<BookAuthor, UniqueEntity<BookAuthorData>>  {
        protected override BookAuthor createObj() => new(GetRandom.Value<BookAuthorData>());
        [TestMethod] public void BookIDTest() => isReadOnly(obj.Data.BookID);
        [TestMethod] public void AuthorIDTest() => isReadOnly(obj.Data.AuthorID);
        [TestMethod]
        public void BookTest() => itemTest<IBooksRepo, Book, BookData>(
            obj.BookID, d => new Book(d), () => obj.Book);
        [TestMethod]
        public void AuthorTest() => itemTest<IAuthorsRepo, Author, AuthorData>(
            obj.AuthorID, d => new Author(d), () => obj.Author);
    }
}
