using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Facade.Party
{
    public sealed class CityView: UniqueView
    {
        [DisplayName("Name")] public string? Name { get; set; }
        [DisplayName("County")]  public string? County { get; set; }
        [DisplayName("Country")] public string? CountryID { get; set; }

    }
    public sealed class CityViewFactory : BaseViewFactory<CityView, City, CityData>
    {
        protected override City toEntity(CityData d) => new(d);
    }
}
