using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public class LoansRepo : Repo<Loaned, LoanedData>, ILoansRepo
    {
        public LoansRepo(RakendusDb? db) : base(db, db?.Loans) { }
        protected override Loaned toDomain(LoanedData d) => new Loaned(d);
    }
}
