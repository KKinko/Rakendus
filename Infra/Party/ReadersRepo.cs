using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class ReadersRepo : Repo<Reader, ReaderData>, IReadersRepo 
    {
        public ReadersRepo(RakendusDb? db) : base(db, db?.Readers) { }
        protected internal override Reader toDomain(ReaderData d) => new(d);
        internal override IQueryable<ReaderData> addFilter(IQueryable<ReaderData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.FirstName.Contains(y)
                || x.LastName.Contains(y)
                || x.ID.Contains(y)
                || x.DoB.ToString().Contains(y)
                || x.Telephone.ToString().Contains(y)
                || x.CityID.Contains(y)
                || x.HomeAddress.Contains(y)
                || x.Gender.ToString().Contains(y));
        }
    }
}
