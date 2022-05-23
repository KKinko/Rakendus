using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class CountriesRepo : Repo<Country, CountryData>, ICountriesRepo
    {
        public CountriesRepo(RakendusDb? db) : base(db, db?.Countries) { }
        protected internal override Country toDomain(CountryData d) => new(d);
        internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q)
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
