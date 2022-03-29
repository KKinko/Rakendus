using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Infra;

namespace Rakendus.Tests.Infra
{
    [TestClass] public class RepoTests : AbstractClassTests
    {
        private class testClass: Repo<Book, BookData>
        {
            public testClass(DbContext? c, DbSet<BookData>? s) : base(c, s){ }
            protected override Book toDomain(BookData d) => new (d);
        }
        protected override object createObj() => new testClass(null, null);
    }
}
