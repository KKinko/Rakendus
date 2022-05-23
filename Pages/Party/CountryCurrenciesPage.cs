using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    public class CountryCurrenciesPage : PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrenciesRepo>
    {
        private readonly ICountriesRepo countries;
        private readonly ICurrenciesRepo currencies;

        public CountryCurrenciesPage(ICountryCurrenciesRepo r, ICountriesRepo co, ICurrenciesRepo cu) : base(r) 
        {
            countries = co;
            currencies = cu;
        }

        protected override CountryCurrency toObject(CountryCurrencyView? item) => new CountryCurrencyViewFactory().Create(item);

        protected override CountryCurrencyView toView(CountryCurrency? entity) => new CountryCurrencyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryCurrencyView.CountryID),
            nameof(CountryCurrencyView.CurrencyID),
            nameof(CountryCurrencyView.Code),
            nameof(CountryCurrencyView.Name),
            nameof(CountryCurrencyView.Description)
        };
        public IEnumerable<SelectListItem> Countries
            => countries?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Currencies
            => currencies?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
        public string CountryName(string? countryID = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryID ?? string.Empty))?.Text ?? "Unspecified";
        public string CurrencyName(string? currencyID = null)
            => Currencies?.FirstOrDefault(x => x.Value == (currencyID ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, CountryCurrencyView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(CountryCurrencyView.CountryID) ? CountryName(r as string)
                : name == nameof(CountryCurrencyView.CurrencyID) ? CurrencyName(r as string)
                : r;
        }
    }
}

