using Rakendus.Data;
using Rakendus.Data.Party;
using System.Globalization;

namespace Rakendus.Infra.Initializers
{
    public sealed class CurrenciesInitializer : BaseInitializer<CurrencyData>
    {
        public CurrenciesInitializer(RakendusDb? db) : base(db, db?.Currencies) { }
        protected override IEnumerable<CurrencyData> getEntities
        {
            get
            {
                var l = new List<CurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = c.ISOCurrencySymbol;
                    if (!isCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.ID == c.ISOCurrencySymbol) is not null) continue;
                    var d = createCurrency(c.ISOCurrencySymbol, c.CurrencyEnglishName, c.CurrencyNativeName);
                    l.Add(d);
                }
                return l;
            }
        }

        internal static CurrencyData createCurrency(string code, string name, string description)
            => new() { ID = code ?? UniqueData.NewID, 
                Code = code ?? UniqueData.NewID, 
                Name = name, 
                Description = description 
            };
    }
}

