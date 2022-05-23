using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;
using Rakendus.Infra.Party;

namespace Rakendus.Tests.Infra.Party
{
    [TestClass]
    public class BooksAuthorsRepoTests : SealedRepoTests<BooksAuthorsRepo, Repo<BookAuthor, BookAuthorData>, BookAuthor, BookAuthorData>
    {
        protected override BooksAuthorsRepo createObj() => new(GetRepo.Instance<RakendusDb>());
        protected override object? getSet(RakendusDb db) => db.BooksAuthors;
    }
}
