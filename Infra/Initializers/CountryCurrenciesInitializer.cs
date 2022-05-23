using Rakendus.Data;
using Rakendus.Data.Party;
using Rakendus.Domain;
using System.Globalization;

namespace Rakendus.Infra.Initializers
{
    public sealed class CountryCurrenciesInitializer : BaseInitializer<CountryCurrencyData>
    {
        public CountryCurrenciesInitializer(RakendusDb? db) : base(db, db?.CountryCurrencies) { }
        protected override IEnumerable<CountryCurrencyData> getEntities
        {
            get
            {
                var l = new List<CountryCurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var countryID = c.ThreeLetterISORegionName;
                    var currencyID = c.ISOCurrencySymbol;
                    var nativeName = c.CurrencyNativeName;
                    var currencyCode = c.CurrencySymbol;
                    var d = createEntity(countryID, currencyID, currencyCode, nativeName);
                    l.Add(d);
                }
                return l;
            }
        }

        internal static CountryCurrencyData createEntity(string countryId, string currencyId,
            string code, string? name = null, string? description = null)
            => new()
            {
                ID = UniqueData.NewID,
                CurrencyID = currencyId,
                CountryID = countryId,
                Code = code ?? UniqueEntity.defaultStr,
                Name = name,
                Description = description
            };
    }
}

