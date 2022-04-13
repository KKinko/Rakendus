using Rakendus.Data.Party;
namespace Rakendus.Domain.Party
{
    public interface IReadersRepo : IRepo<Reader> { }
    public sealed class Reader : Entity<ReaderData>
    {
        public Reader() : this(new ReaderData()) { }
        public Reader (ReaderData d) :base(d) { }
       
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public bool Gender => getValue(Data?.Gender);
        public DateTime DoB => getValue(Data?.DoB);
        public int Telephone => getValue(Data?.Telephone);
        public string City => getValue(Data?.City);
        public string HomeAddress => getValue(Data?.HomeAddress);
        public string Education => getValue(Data?.Education);
        public string EmailAddress => getValue(Data?.EmailAddress);
        public override string ToString() => $"{FirstName} {LastName} ({Gender}, {DoB}, {Telephone} {City})";
    }
}