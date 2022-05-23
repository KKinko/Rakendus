using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;

namespace Rakendus.Tests.Infra {
    [TestClass] public class BaseRepoTests 
        : AbstractClassTests<BaseRepo<Book, BookData>, object> {
        private class testClass : BaseRepo<Book, BookData> {
            public testClass(DbContext? c, DbSet<BookData>? s) : base(c, s) { }
            public override bool Add(Book obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(Book obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override List<Book> Get() => throw new NotImplementedException();
            public override Book Get(string id) => throw new NotImplementedException();
            public override List<Book> GetAll(Func<Book, dynamic>? orderBy = null)
                => throw new NotImplementedException();
            public override Task<List<Book>> GetAsync() => throw new NotImplementedException();
            public override Task<Book> GetAsync(string id) => throw new NotImplementedException();
            public override bool Update(Book obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(Book obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<Book, BookData> createObj() => new testClass(null, null);
        [TestMethod] public void dbTest() => isReadOnly<DbContext?>();
        [TestMethod] public void setTest() => isReadOnly<DbSet<BookData>?>();
        [TestMethod] public void BaseRepoTest() {
            var db = GetRepo.Instance<RakendusDb>();
            var set = db?.Books;
            isNotNull(set);
            obj = new testClass(db, set);
            areEqual(db, obj.db);
            areEqual(set, obj.set);
        }
        [TestMethod] public async Task ClearTest() {
            BaseRepoTest();
            var cnt = GetRandom.Int32(5, 30);
            var db = obj.db;
            isNotNull(db);
            var set = obj.set;
            isNotNull(set);
            for (var i = 0; i < cnt; i++) set.Add(GetRandom.Value<BookData>());
            areEqual(0, await set.CountAsync());
            db.SaveChanges();
            areEqual(cnt, await set.CountAsync());
            obj.clear();
            areEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => isAbstractMethod(nameof(obj.Add), typeof(Book));
        [TestMethod] public void AddAsyncTest() => isAbstractMethod(nameof(obj.AddAsync), typeof(Book));
        [TestMethod] public void DeleteTest() => isAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void DeleteAsyncTest() => isAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
        [TestMethod] public void GetTest() => isAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetAllTest() => isAbstractMethod(nameof(obj.GetAll), typeof(Func<Book, dynamic>));
        [TestMethod] public void GetListTest() => isAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAsyncTest() => isAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetListAsyncTest() => isAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateTest() => isAbstractMethod(nameof(obj.Update), typeof(Book));
        [TestMethod] public void UpdateAsyncTest() => isAbstractMethod(nameof(obj.UpdateAsync), typeof(Book));
    }
}

