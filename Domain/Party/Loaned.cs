using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface ILoansRepo : IRepo<Loaned> { }
    public sealed class Loaned : UniqueEntity<LoanedData>
    {
        public Loaned() : this(new ()) { }
        public Loaned(LoanedData d) : base(d) { }


        public DateTime LoanedDate => getValue(Data?.LoanedDate);
        public DateTime LoanedReturned => getValue(Data?.LoanedReturned);

        public string ItemID => getValue(Data?.ItemID);
        public string ReaderID => getValue(Data?.ReaderID);

    }
}
