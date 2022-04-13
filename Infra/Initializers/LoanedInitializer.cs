using Rakendus.Data.Party;

namespace Rakendus.Infra.Initializers
{
    public sealed class LoanedInitializer : BaseInitializer<LoanedData>
    {
        public LoanedInitializer(RakendusDb? db) : base(db, db?.Loans) { }
        internal static LoanedData createLoaned(string item, string name, DateTime loanedDate, DateTime loanedReturned)
        {
            var loaned = new LoanedData
            {
                ID = name + item,
                BookItem = item,
                Reader = name,
                LoanedDate = loanedDate,
                LoanedReturned = loanedReturned
            };
            return loaned;
        }
        protected override IEnumerable<LoanedData> getEntities => new[] {
            createLoaned("1313", "Mari Lepp", new DateTime(1980, 07, 31), new DateTime(1980, 08, 14)),
            createLoaned("132", "Karl Kukk", new DateTime(1998, 07, 22), new DateTime(2000, 07, 12))
        };
    }
}
