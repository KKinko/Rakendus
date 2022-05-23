using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;

namespace Rakendus.Tests.Infra {
    [TestClass] public class OrderedRepoTests
        : AbstractClassTests<OrderedRepo<Book, BookData>, FilteredRepo<Book, BookData>> {
        private class testClass : OrderedRepo<Book, BookData> {
            public testClass(DbContext? c, DbSet<BookData>? s) : base(c, s) { }
            protected internal override Book toDomain(BookData d) => new(d);
        }
        protected override OrderedRepo<Book, BookData> createObj() {
            var db = GetRepo.Instance<RakendusDb>();
            var set = db?.Books;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentOrderTest() => isProperty<string?>();
        [TestMethod] public void DescendingStringTest() => areEqual("_desc", testClass.DescendingString);
        [DataRow(null, true)]
        [DataRow(null, false)]
        [DataRow(nameof(Book.ID), true)]
        [DataRow(nameof(Book.ID), false)]
        [DataRow(nameof(Book.Isbn), true)]
        [DataRow(nameof(Book.Isbn), false)]
        [DataRow(nameof(Book.Title), true)]
        [DataRow(nameof(Book.Title), false)]
        [DataRow(nameof(Book.Field), true)]
        [DataRow(nameof(Book.Field), false)]
        [TestMethod] public void CreateSqlTest(string s, bool isDescending) { 
            obj.CurrentOrder = (s is null)? s: isDescending? s + testClass.DescendingString: s;
            var q = obj.createSql();
            var actual = q.Expression.ToString();
            if (s is null) isTrue(actual.EndsWith(".Select(s => s)"));
            else if (isDescending) isTrue(actual.EndsWith(
                $".Select(s => s).OrderByDescending(x => Convert(x.{s}, Object))"));
            else isTrue(actual.EndsWith(
                $".Select(s => s).OrderBy(x => Convert(x.{s}, Object))"));
        }

        [DataRow(true, true)]
        [DataRow(false, true)]
        [DataRow(true, false)]
        [DataRow(false, false)]
        [TestMethod] public void SortOrderTest(bool isDescending, bool isSame) {
            var s = GetRandom.String();
            var c = isSame ? s : GetRandom.String();
            obj.CurrentOrder = isDescending ? c + testClass.DescendingString : c;
            var actual = obj.SortOrder(s);
            var sDes = s+testClass.DescendingString;
            var expected = isSame ? (isDescending? s: sDes) : sDes;
            areEqual(expected, actual);
        }
    }
}

