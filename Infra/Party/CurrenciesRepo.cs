using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrenciesRepo
    {
        public CurrenciesRepo(RakendusDb? db) : base(db, db?.Currencies) { }
        protected internal override Currency toDomain(CurrencyData d) => new(d);
        internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
               x => x.Code.Contains(y)
                || x.Description.Contains(y)
                || x.ID.Contains(y)
                || x.Name.Contains(y));
        }
    }
}
