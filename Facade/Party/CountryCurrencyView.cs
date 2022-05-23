using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public sealed class CountryCurrencyView : NamedView
    {
        [Required][DisplayName("Country")] public string CountryID { get; set; } = string.Empty;
        [Required][DisplayName("Currency")] public string CurrencyID { get; set; } = string.Empty;
        [DisplayName("Currency Native Code")] public new string? Code { get; set; }
        [DisplayName("Currency Native Name")] public new string? Name { get; set; }
    }
    public sealed class CountryCurrencyViewFactory : 
        BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData>
    {
        protected override CountryCurrency toEntity(CountryCurrencyData d) => new(d);
    }
}
