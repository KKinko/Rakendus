using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Infra.Party
{
    public sealed class LoansRepo : Repo<Loaned, LoanedData>, ILoansRepo
    {
        public LoansRepo(RakendusDb? db) : base(db, db?.Loans) { }
        protected internal override Loaned toDomain(LoanedData d) => new(d);
        internal override IQueryable<LoanedData> addFilter(IQueryable<LoanedData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
               x => x.ItemID.Contains(y)
                || x.ReaderID.Contains(y)
                || x.ID.Contains(y)
                || x.LoanedDate.ToString().Contains(y)
                || x.LoanedReturned.ToString().Contains(y));
        }
    }
}
