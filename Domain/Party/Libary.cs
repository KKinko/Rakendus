using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface ILibariesRepo : IRepo<Libary> { }
    public sealed class Libary : UniqueEntity<LibaryData>
    {
        public Libary() : this(new ()) { }
        public Libary(LibaryData d) : base(d) { }
        public string Name => getValue(Data?.Name);
        public string Address => getValue(Data?.Address);
        public string CityID => getValue(Data?.CityID);
    }


}

