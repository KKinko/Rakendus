using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class CountryCurrenciesRepo : Repo<CountryCurrency, CountryCurrencyData>, ICountryCurrenciesRepo
    {
        public CountryCurrenciesRepo(RakendusDb? db) : base(db, db?.CountryCurrencies) { }
        protected internal override CountryCurrency toDomain(CountryCurrencyData d) => new(d);

        internal override IQueryable<CountryCurrencyData> addFilter(IQueryable<CountryCurrencyData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.CurrencyID.Contains(y)
                 || x.CountryID.Contains(y)
                 || x.ID.Contains(y)
                 || x.Description.Contains(y)
                 || x.Code.Contains(y)
                 || x.Name.Contains(y));
        }
    }
}
