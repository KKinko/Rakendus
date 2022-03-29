using Microsoft.EntityFrameworkCore;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public class ReadersRepo : Repo<Reader, ReaderData>, IReadersRepo 
    {
        public ReadersRepo(DbContext c, DbSet<ReaderData> s) : base(c, s) { }
        protected override Reader toDomain(ReaderData d) => new Reader(d);
    }
}
