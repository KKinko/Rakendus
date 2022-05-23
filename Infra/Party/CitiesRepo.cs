using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class CitiesRepo : Repo<City, CityData>, ICitiesRepo
    {
        public CitiesRepo(RakendusDb? db) : base(db, db?.Cities) { }
        protected internal override City toDomain(CityData d) => new(d);

        internal override IQueryable<CityData> addFilter(IQueryable<CityData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.Name.Contains(y)
                 || x.ID.Contains(y)
                 || x.County.Contains(y)
                 || x.CountryID.Contains(y));
        }
    }
}
