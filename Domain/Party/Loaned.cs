using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface ILoansRepo : IRepo<Loaned> { }
    public sealed class Loaned : Entity<LoanedData>
    {
        public Loaned() : this(new LoanedData()) { }
        public Loaned(LoanedData d) : base(d) { }


        public DateTime? LoanedDate => getValue(Data?.LoanedDate);
        public DateTime? LoanedDue => getValue(Data?.LoanedDue);
        public DateTime? LoanedReturned => getValue(Data?.LoanedReturned);
        public int? OverdueFine => getValue(Data?.OverdueFine);
        public bool? LoanedStatus => getValue(Data?.LoanedStatus);



    }
}
