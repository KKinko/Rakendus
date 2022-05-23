using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party {
    [TestClass] public class AuthorTests: SealedClassTests<Author, PersonEntity<AuthorData>> {
        protected override Author createObj() => new (GetRandom.Value<AuthorData>());

        [TestMethod]
        public void BooksAuthorsTest()
            => itemsTest<IBooksAuthorsRepo, BookAuthor, BookAuthorData>(
                d => d.AuthorID = obj.ID, d => new BookAuthor(d), () => obj.BooksAuthors.Value);
        [TestMethod]
        public void BooksTest() => relatedItemsTest<IBooksRepo, BookAuthor, Book, BookData>
            (BooksAuthorsTest, () => obj.BooksAuthors.Value, () => obj.Books.Value,
              x => x.BookID, d => new Book(d), c => c?.Data, x => x?.Book?.Data);
    }
}
