using Data;

namespace Domain
{
    public class Reader
    {
        private const string defaultStr = "Undefined";
        private const int defaultInt = 0;
        private const bool defaultGender = true;

        private DateTime defaultDate => DateTime.MinValue;
        private ReaderData data;

        public Reader() : this(new ReaderData()) { }
        public Reader(ReaderData d) => data = d;


        public string ID => data?.ID ?? defaultStr;
        public string FirstName => data?.FirstName ?? defaultStr;
        public string LastName => data?.LastName ?? defaultStr;
        public bool Gender => data?.Gender ?? defaultGender;
        public DateTime DoB => data?.DoB ?? defaultDate;
        public int Telephone => data?.Telephone ?? defaultInt;
        public string City => data?.City ?? defaultStr;
        public string HomeAddress => data?.HomeAddress ?? defaultStr;
        public string Education => data?.Education ?? defaultStr;
        public string EmailAddress => data?.EmailAddress ?? defaultStr;
        public ReaderData Data => data;
        public override string ToString() => $"{FirstName} {LastName} ({Gender}, {DoB}, {Telephone} {City})";
    }
}