using Rakendus.Data.Party;

namespace Rakendus.Domain.Party
{
    public sealed class Reader : Entity<ReaderData>
    {
        private const string defaultStr = "Undefined";
        private const int defaultInt = 0;
        private const bool defaultGender = true;
        private DateTime defaultDate => DateTime.MinValue;
        public Reader() : this(new ReaderData()) { }
        public Reader (ReaderData d) :base(d) { }
        public string ID => Data?.ID ?? defaultStr;
        public string FirstName => Data?.FirstName ?? defaultStr;
        public string LastName => Data?.LastName ?? defaultStr;
        public bool Gender => Data?.Gender ?? defaultGender;
        public DateTime DoB => Data?.DoB ?? defaultDate;
        public int Telephone => Data?.Telephone ?? defaultInt;
        public string City => Data?.City ?? defaultStr;
        public string HomeAddress => Data?.HomeAddress ?? defaultStr;
        public string Education => Data?.Education ?? defaultStr;
        public string EmailAddress => Data?.EmailAddress ?? defaultStr;
        public override string ToString() => $"{FirstName} {LastName} ({Gender}, {DoB}, {Telephone} {City})";
    }
}