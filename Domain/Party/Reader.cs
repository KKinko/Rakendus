using Rakendus.Aids;
using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public interface IReadersRepo : IRepo<Reader> { }
    public sealed class Reader : PersonEntity<ReaderData>
    {
        public Reader() : this(new ()) { }
        public Reader (ReaderData d) :base(d) { }
       
        public IsoGender? Gender => getValue(Data?.Gender);
        public int Telephone => getValue(Data?.Telephone);
        public string CityID => getValue(Data?.CityID);
        public string HomeAddress => getValue(Data?.HomeAddress);
        public string LoanedID => getValue(Data?.LoanedID);
        public override string ToString() => $"{FirstName} {LastName} ({Gender?.Description()}, {DoB})";
    }

}