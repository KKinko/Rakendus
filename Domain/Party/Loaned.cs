using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface ILoansRepo : IRepo<Loaned> { }
    public sealed class Loaned : Entity<LoanedData>
    {
        public Loaned() : this(new LoanedData()) { }
        public Loaned(LoanedData d) : base(d) { }


        public string? BookItem => getValue(Data?.BookItem);
        public string? Reader => getValue(Data?.Reader);
        public DateTime? LoanedDate => getValue(Data?.LoanedDate);
        public DateTime? LoanedReturned => getValue(Data?.LoanedReturned);

    }
}
