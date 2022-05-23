using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;
using Rakendus.Infra.Party;

namespace Rakendus.Tests.Infra.Party
{
    [TestClass]
    public class LoansRepoTests : SealedRepoTests<LoansRepo, Repo<Loaned, LoanedData>, Loaned, LoanedData>
    {
        protected override LoansRepo createObj() => new(GetRepo.Instance<RakendusDb>());
        protected override object? getSet(RakendusDb db) => db.Loans;
    }
}
