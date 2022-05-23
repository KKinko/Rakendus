using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface ICitiesRepo : IRepo<City> { }
    public sealed class City: UniqueEntity<CityData>
    {
        public City() : this(new ()) { }
        public City(CityData d) : base(d) { }

        public string Name => getValue(Data?.Name);
        public string County => getValue(Data?.County);
        public string CountryID => getValue(Data?.CountryID);
    }
}
