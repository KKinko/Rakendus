using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Facade.Party
{
    public sealed class CurrencyView : IsoNamedView { }
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData>
    {
        protected override Currency toEntity(CurrencyData d) => new(d);
    }
}
