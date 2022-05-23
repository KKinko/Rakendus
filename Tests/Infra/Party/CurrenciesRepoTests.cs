using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain;
using Rakendus.Domain.Party;
using Rakendus.Infra;
using Rakendus.Infra.Party;

namespace Rakendus.Tests.Infra.Party {
    [TestClass] public class CurrenciesRepoTests 
        : SealedRepoTests<CurrenciesRepo, Repo<Currency, CurrencyData>, Currency, CurrencyData> {
        protected override CurrenciesRepo createObj() => new (GetRepo.Instance<RakendusDb>());
        protected override object? getSet(RakendusDb db) => db.Currencies;
    }
}
