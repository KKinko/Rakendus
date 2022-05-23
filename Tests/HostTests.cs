using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Rakendus.Aids;
using Rakendus.Data;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra.Party;

namespace Rakendus.Tests
{
    public abstract class HostTests : TestAsserts
    {
        internal static readonly TestHost<Program> host;
        internal static readonly HttpClient client;
        [TestInitialize]
        public virtual void TestInitialize()
        {
            (GetRepo.Instance<ICountriesRepo>() as CountriesRepo)?.clear();
            (GetRepo.Instance<ICurrenciesRepo>() as CurrenciesRepo)?.clear();
            (GetRepo.Instance<ICountryCurrenciesRepo>() as CountryCurrenciesRepo)?.clear();
            (GetRepo.Instance<IBooksRepo>() as BooksRepo)?.clear();
            (GetRepo.Instance<IReadersRepo>() as ReadersRepo)?.clear();
            (GetRepo.Instance<ILoansRepo>() as LoansRepo)?.clear();
            (GetRepo.Instance<IItemsRepo>() as ItemsRepo)?.clear();
            (GetRepo.Instance<ILibariesRepo>() as LibariesRepo)?.clear();
            (GetRepo.Instance<IAuthorsRepo>() as AuthorsRepo)?.clear();
            (GetRepo.Instance<IBooksAuthorsRepo>() as BooksAuthorsRepo)?.clear();
            (GetRepo.Instance<ICitiesRepo>() as CitiesRepo)?.clear();
        }
        static HostTests()
        {
            host = new TestHost<Program>();
            client = host.CreateClient();
        }
        protected virtual object? isReadOnly<T>(string? callingMethod = null) => null;
        protected virtual void arePropertiesEqual(object? x, object? y, params string[] excluded) { isInconclusive(); }
        protected void itemTest<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObj)
            where TRepo : class, IRepo<TObj> where TObj : UniqueEntity
        {
            var c = isReadOnly<TObj>(nameof(itemTest));
            isNotNull(c);
            isInstanceOfType(c, typeof(TObj));
            var r = GetRepo.Instance<TRepo>();
            int cnt;
            var d = addRandomItems(out cnt, toObj, id, r);
            r.PageSize = 30;
            areEqual(cnt, r.Get().Count);
            areEqualProperties(d, getObj(), nameof(UniqueData.Token));
        }

        internal static TData? addRandomItems<TRepo, TObj, TData>(out int cnt, Func<TData, TObj> toObj, string? id = null, TRepo? r = null)
            where TRepo : class, IRepo<TObj>
            where TObj : UniqueEntity {
            r ??= GetRepo.Instance<TRepo>();
            var d = GetRandom.Value<TData>();
            if (id is not null && d is not null) d.ID = id;
            cnt = GetRandom.Int32(5, 30);
            var idx = GetRandom.Int32(0, cnt);
            for (var i = 0; i < cnt; i++) {
                var x = (i == idx) ? d : GetRandom.Value<TData>();
                isNotNull(x);
                r?.Add(toObj(x));
            }
            return d;
        }

        protected void itemsTest<TRepo, TObj, TData>(Action<TData> setId, Func<TData, TObj> toObj, Func<List<TObj>> getList)
            where TRepo : class, IRepo<TObj> where TObj : UniqueEntity<TData> where TData : UniqueData, new()
        {
            var o = isReadOnly<List<TObj>>(nameof(itemsTest));

            isNotNull(o);
            if (o.GetType().Name.Contains("Lazy")) isInstanceOfType(o, typeof(Lazy<List<TObj>>));
            else isInstanceOfType(o, typeof(List<TObj>));

            var r = GetRepo.Instance<TRepo>();
            isNotNull(r);

            var list = new List<TData>();
            var cnt = GetRandom.Int32(5, 30);
            for (var i = 0; i < cnt; i++)
            {
                var x = GetRandom.Value<TData>();
                if (GetRandom.Bool())
                {
                    setId(x);
                    list.Add(x);
                }
                r.Add(toObj(x));
            }
            r.PageSize = 30;
            areEqual(cnt, r.Get().Count);

            var l = getList();
            areEqual(list.Count, l.Count);
            foreach (var d in list)
            {
                var y = l.Find(z => z.ID == d.ID);
                isNotNull(y);
                areEqualProperties(d, y, nameof(UniqueData.Token));
            }
        }

        protected void relatedItemsTest<TRepo, TRelatedItem, TItem, TData>
            (Action relatedTest,
            Func<List<TRelatedItem>> relatedItems,
            Func<List<TItem?>> items,
            Func<TRelatedItem, string> detailId,
            Func<TData, TItem> toObj,
            Func<TItem?, TData?> toData,
            Func<TRelatedItem?, TData?> relatedToData)
           where TRepo : class, IRepo<TItem>
           where TItem : UniqueEntity
           where TRelatedItem : UniqueEntity
        {
            relatedTest();
            var l = relatedItems();
            var r = GetRepo.Instance<TRepo>();
            foreach (var e in l)
            {
                var x = GetRandom.Value<TData>();
                if (x is not null) x.ID = detailId(e);
                r?.Add(toObj(x));
            }
            var c = items();
            areEqual(l.Count, c.Count);
            foreach (var e in l)
            {
                var a = c.Find(x => x?.ID == detailId(e));
                arePropertiesEqual(toData(a), relatedToData(e), nameof(UniqueData.Token));
            }
        }
    }
}
