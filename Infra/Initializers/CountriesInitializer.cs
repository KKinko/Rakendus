using Rakendus.Data;
using Rakendus.Data.Party;
using System.Globalization;

namespace Rakendus.Infra.Initializers
{
    public sealed class CountriesInitializer : BaseInitializer<CountryData>
    {
        public CountriesInitializer(RakendusDb? db) : base(db, db?.Countries) { }
        protected override IEnumerable<CountryData> getEntities
        {
            get
            {
                var l = new List<CountryData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = c.ThreeLetterISORegionName;
                    if (!isCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.ID == id) is not null) continue;
                    var d = createCountry(id, c.EnglishName, c.NativeName);
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CountryData createCountry(string code, string name, string description)
            => new() { ID = code ?? UniqueData.NewID, 
                Code = code ?? UniqueData.NewID, 
                Name = name, 
                Description = description 
            };
    }
}
