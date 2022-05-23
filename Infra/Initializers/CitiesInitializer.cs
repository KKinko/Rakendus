using Rakendus.Data.Party;
using System.Globalization;

namespace Rakendus.Infra.Initializers
{
    public sealed class CitiesInitializer : BaseInitializer<CityData>
    {
        public CitiesInitializer(RakendusDb? db) : base(db, db?.Cities) { }
        protected override IEnumerable<CityData> getEntities
        {
            
            get
            {
                    string fileName = "citiesEE.txt";
                    var l = new List<CityData>();
                    try
                    {
                    using (StreamReader reader = new(fileName))
                        {
                            while (!reader.EndOfStream)
                            {
                            string? line = reader.ReadLine();
                            string[] splitInfo = line.Split(';');
                            if (!(splitInfo.Count() == 2)) continue;
                                var d = createCountry(splitInfo[0], splitInfo[1]);
                                l.Add(d);
                            }
                        }
                        return l;
                    }
                    catch
                    {
                        return Enumerable.Empty<CityData>();
                    }
            }
        }
             internal static CityData createCountry(string name, string couty)
             => new() { ID = name, Name = name, County = couty };
    }
}
