using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public class ReadersRepo : Repo<Reader, ReaderData>, IReadersRepo 
    {
        public ReadersRepo(RakendusDb? db) : base(db, db?.Readers) { }
        protected override Reader toDomain(ReaderData d) => new Reader(d);
    }
}
