using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Infra;
using Rakendus.Infra.Initializers;

namespace Rakendus.Tests.Infra.Initializers {

    [TestClass] public class BooksInitializerTests
        : SealedBaseTests<BooksInitializer, BaseInitializer<BookData>> {
        protected override BooksInitializer createObj() {
            var db = GetRepo.Instance<RakendusDb>();
            return new BooksInitializer(db);
        }
    }
    [TestClass]
    public class ItemsInitializerTests
    : SealedBaseTests<ItemsInitializer, BaseInitializer<ItemData>>
    {
        protected override ItemsInitializer createObj()
        {
            var db = GetRepo.Instance<RakendusDb>();
            return new ItemsInitializer(db);
        }
    }
    [TestClass]
    public class LoanedInitializerTests
    : SealedBaseTests<LoanedInitializer, BaseInitializer<LoanedData>>
    {
        protected override LoanedInitializer createObj()
        {
            var db = GetRepo.Instance<RakendusDb>();
            return new LoanedInitializer(db);
        }
    }
    [TestClass]
    public class ReadersInitializerTests
    : SealedBaseTests<ReadersInitializer, BaseInitializer<ReaderData>>
    {
        protected override ReadersInitializer createObj()
        {
            var db = GetRepo.Instance<RakendusDb>();
            return new ReadersInitializer(db);
        }
    }
    [TestClass] public class CitiesInitializerTests
        : SealedBaseTests<CitiesInitializer, BaseInitializer<CityData>> {
        protected override CitiesInitializer createObj() {
            var db = GetRepo.Instance<RakendusDb>();
            return new CitiesInitializer(db);
        }
    }
    [TestClass] public class CountriesInitializerTests
        : SealedBaseTests<CountriesInitializer, BaseInitializer<CountryData>> {
        protected override CountriesInitializer createObj() {
            var db = GetRepo.Instance<RakendusDb>();
            return new CountriesInitializer(db);
        }
    }
    [TestClass] public class CurrenciesInitializerTests
        : SealedBaseTests<CurrenciesInitializer, BaseInitializer<CurrencyData>> {
        protected override CurrenciesInitializer createObj() {
            var db = GetRepo.Instance<RakendusDb>();
            return new CurrenciesInitializer(db);
        }
    }
    [TestClass] public class CountryCurrenciesInitializerTests
        : SealedBaseTests<CountryCurrenciesInitializer, BaseInitializer<CountryCurrencyData>> {
        protected override CountryCurrenciesInitializer createObj() {
            var db = GetRepo.Instance<RakendusDb>();
            return new CountryCurrenciesInitializer(db);
        }
    }
    [TestClass] public class BaseInitializerTests
        : AbstractClassTests<BaseInitializer<BookData>, object> {
        private class testClass : BaseInitializer<BookData> {
            public testClass(DbContext? c, DbSet<BookData>? s) : base(c, s) { }
            protected override IEnumerable<BookData> getEntities => throw new System.NotImplementedException();
        }
        protected override BaseInitializer<BookData> createObj() {
            var db = GetRepo.Instance<RakendusDb>();
            var set = db?.Books;
            return new testClass(db, set);
        }
    }
    [TestClass] public class RakendusDbInitializerTests : TypeTests { }
}