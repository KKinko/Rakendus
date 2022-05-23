using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;

namespace Rakendus.Tests.Infra {
    [TestClass] public class FilteredRepoTests 
        : AbstractClassTests<FilteredRepo<Book, BookData>, CrudRepo<Book, BookData>> {
        private class testClass : FilteredRepo<Book, BookData> {
            public testClass(DbContext? c, DbSet<BookData>? s) : base(c, s) { }
            protected internal override Book toDomain(BookData d) => new(d);
        }
        protected override FilteredRepo<Book, BookData> createObj() {
            var db = GetRepo.Instance<RakendusDb>();
            var set = db?.Books;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentFilterTest() => isProperty<string>();
        [DataRow(true)]
        [DataRow(false)]
        [TestMethod] public void CreateSqlTest(bool hasCurrentFilter) {
            obj.CurrentFilter = hasCurrentFilter ? GetRandom.String(): null;
            var q1 = obj.createSql();
            var q2 = obj.addFilter(q1);
            areEqual(q1, q2);
            var s = q1.Expression.ToString();
            isTrue(s.EndsWith(".Select(s => s)"));
        }
    }
}

