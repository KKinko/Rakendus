using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;
using Rakendus.Infra.Party;

namespace Rakendus.Tests.Infra.Party
{
    [TestClass]
    public class BooksRepoTests : SealedRepoTests<BooksRepo, Repo<Book, BookData>, Book, BookData>
    {
        protected override BooksRepo createObj() => new(GetRepo.Instance<RakendusDb>());
        protected override object? getSet(RakendusDb db) => db.Books;
    }
}
