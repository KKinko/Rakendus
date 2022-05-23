using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class AuthorsRepo : Repo<Author, AuthorData>, IAuthorsRepo
    {
        public AuthorsRepo(RakendusDb? db) : base(db, db?.Authors) { }
        protected internal override Author toDomain(AuthorData d) => new(d);
        internal override IQueryable<AuthorData> addFilter(IQueryable<AuthorData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
               x => x.FirstName.Contains(y)
                || x.LastName.Contains(y)
                || x.ID.Contains(y)
                || x.DoB.ToString().Contains(y));
        }
    }
}
