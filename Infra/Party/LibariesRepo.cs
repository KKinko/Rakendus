using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class LibariesRepo : Repo<Libary, LibaryData>, ILibariesRepo
    {
        public LibariesRepo(RakendusDb? db) : base(db, db?.Libaries) { }
        protected internal override Libary toDomain(LibaryData d) => new(d);
        internal override IQueryable<LibaryData> addFilter(IQueryable<LibaryData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
               x => x.Address.Contains(y)
                || x.CityID.Contains(y)
                || x.ID.Contains(y)
                || x.Name.Contains(y));
        }
    }
}
