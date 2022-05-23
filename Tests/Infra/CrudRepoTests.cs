using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;

namespace Rakendus.Tests.Infra {
    [TestClass] public class CrudRepoTests
        : AbstractClassTests<CrudRepo<Book, BookData>, BaseRepo<Book, BookData>> {
        private RakendusDb? db;
        private DbSet<BookData>? set;
        private BookData? d;
        private Book? a;
        private int cnt;

        private class testClass : CrudRepo<Book, BookData> {
            public testClass(DbContext? c, DbSet<BookData>? s) : base(c, s) { }
            protected internal override Book toDomain(BookData d) => new(d);
        }
        protected override CrudRepo<Book, BookData> createObj() {
            db = GetRepo.Instance<RakendusDb>();
            set = db?.Books;
            isNotNull(set);
            return new testClass(db, set);
        }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            initSet();
            initAdr();
        }
        private void initSet() {
            cnt = GetRandom.Int32(5, 15);
            for (var i = 0; i < cnt; i++) set?.Add(GetRandom.Value<BookData>());
            _ = db?.SaveChanges();
        }
        private void initAdr() {
            d = GetRandom.Value<BookData>();
            isNotNull(d);
            a = new Book(d);
            var x = obj.Get(d.ID);
            isNotNull(x);
            areNotEqual(d.ID, x.ID);
        }
        [TestMethod] public async Task AddTest() {
            isNotNull(a);
            isNotNull(set);
            _ = obj?.Add(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task AddAsyncTest() {
            isNotNull(a);
            isNotNull(set);
            _ = await obj.AddAsync(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task DeleteTest() {
            isNotNull(d);
            await GetTest();
            _ = obj.Delete(d.ID);
            var x = obj.Get(d.ID);
            isNotNull(x);
            areNotEqual(d.ID, x.ID);
        }
        [TestMethod] public async Task DeleteAsyncTest() {
            isNotNull(d);
            await GetTest();
            _ = await obj.DeleteAsync(d.ID);
            var x = obj.Get(d.ID);
            isNotNull(x);
            areNotEqual(d.ID, x.ID);
        }
        [TestMethod] public async Task GetTest() {
            isNotNull(d);
            await AddTest();
            var x = obj.Get(d.ID);
            arePropertiesEqual(d, x.Data);
        }

        [DataRow(nameof(Book.ID))]
        [DataRow(nameof(Book.Isbn))]
        [DataRow(nameof(Book.Title))]
        [DataRow(nameof(Book.Field))]    
        [DataRow(nameof(Book.PublishDate))]
        [DataRow(nameof(Book.PageCount))]
        [DataRow(null)]
        [TestMethod] public void GetAllTest(string s) {
            Func<Book, dynamic>? orderBy = null;
            if (s is nameof(Book.ID)) orderBy = x => x.ID;
            else if (s is nameof(Book.Isbn)) orderBy = x => x.Isbn;
            else if (s is nameof(Book.Title)) orderBy = x => x.Title;
            else if (s is nameof(Book.Field)) orderBy = x => x.Field;
            else if (s is nameof(Book.PublishDate)) orderBy = x => x.PublishDate;
            else if (s is nameof(Book.PageCount)) orderBy = x => x.PageCount;
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);
            if (orderBy is null) return;
            for(var i = 0; i < l.Count-1; i++) {
                var a = l[i];
                var b = l[i+1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bX);
                var r = aX.CompareTo(bX);
                isTrue(r <= 0);
            }
        }
        [TestMethod] public void GetListTest() {
            var l = obj.Get();
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task GetAsyncTest() {
            isNotNull(d);
            await AddTest();
            var x = await obj.GetAsync(d.ID);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public async Task GetListAsyncTest() {
            var l = await obj.GetAsync();
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task UpdateTest() {
            await GetTest();
            var dX = GetRandom.Value<BookData>() as BookData;
            isNotNull(d);
            isNotNull(dX);
            dX.ID = d.ID;
            var aX = new Book(dX);
            _ = obj.Update(aX);
            var x = obj.Get(d.ID);
            areEqualProperties(dX, x.Data);
        }
        [TestMethod] public async Task UpdateAsyncTest() {
            await GetTest();
            var dX = GetRandom.Value<BookData>() as BookData;
            isNotNull(d);
            isNotNull(dX);
            dX.ID = d.ID;
            var aX = new Book(dX);
            _ = await obj.UpdateAsync(aX);
            var x = obj.Get(d.ID);
            areEqualProperties(dX, x.Data);
        }
    }
}

