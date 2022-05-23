using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Infra;

namespace Rakendus.Tests.Infra {
    [TestClass] public class RepoTests 
        : AbstractClassTests<Repo<Book, BookData>, PagedRepo<Book, BookData>> {
        private class testClass : Repo<Book, BookData> {
            public testClass(DbContext? c, DbSet<BookData>? s) : base(c, s) { }
            protected internal override Book toDomain(BookData d) => new(d);
        }
        protected override Repo<Book, BookData> createObj() => new testClass(null, null);
    }
    [TestClass] public class PagedRepoTests
        : AbstractClassTests<PagedRepo<Book, BookData>, OrderedRepo<Book, BookData>> {
        private class testClass : PagedRepo<Book, BookData> {
            public testClass(DbContext? c, DbSet<BookData>? s) : base(c, s) { }
            protected internal override Book toDomain(BookData d) => new(d);
        }
        protected override PagedRepo<Book, BookData> createObj() => new testClass(null, null);
    }

    [TestClass] public class RakendusDbTests : SealedBaseTests<RakendusDb, DbContext> {
        protected override RakendusDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}

