using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;

namespace Rakendus.Tests.Domain.Party {
    [TestClass]
    public class BookTests : SealedClassTests<Book, UniqueEntity<BookData>>
    {
        protected override Book createObj() => new(GetRandom.Value<BookData>());

        [TestMethod]
        public void BooksAuthorsTest()
            => itemsTest<IBooksAuthorsRepo, BookAuthor, BookAuthorData>(
                d => d.BookID = obj.ID, d => new BookAuthor(d), () => obj.BooksAuthors.Value);
        [TestMethod]
        public void AuthorsTest() => relatedItemsTest<IAuthorsRepo, BookAuthor, Author, AuthorData>
            (BooksAuthorsTest, () => obj.BooksAuthors.Value, () => obj.Authors.Value,
              x => x.AuthorID, d => new Author(d), c => c?.Data, x => x?.Author?.Data);
    }
}
