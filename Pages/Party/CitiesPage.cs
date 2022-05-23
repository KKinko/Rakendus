using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    public class CitiesPage : PagedPage<CityView, City, ICitiesRepo>
    {
        private readonly ICountriesRepo countries;
        public CitiesPage(ICitiesRepo r, ICountriesRepo c ) : base(r) => countries = c;

        protected override City toObject(CityView? item) => new CityViewFactory().Create(item);

        protected override CityView toView(City? entity) => new CityViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CityView.Name),
            nameof(CityView.County),
            nameof(CityView.CountryID)
        };
        public IEnumerable<SelectListItem> Countries
           => countries?.GetAll(x => x.Name)?
           .Select(x => new SelectListItem(x.Name, x.ID))
           ?? new List<SelectListItem>();

        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, CityView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(CityView.CountryID) ? CountryName(r as string) : r;
        }

    }
}

