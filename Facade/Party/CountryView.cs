using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public sealed class CountryView : IsoNamedView { }
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData>
    {
        protected override Country toEntity(CountryData d) => new(d);
    }
}
