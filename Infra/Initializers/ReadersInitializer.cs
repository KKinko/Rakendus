using Rakendus.Data.Party;
namespace Rakendus.Infra.Initializers
{
    public sealed class ReadersInitializer : BaseInitializer<ReaderData>
    {
        public ReadersInitializer(RakendusDb? db) : base(db, db?.Readers) { }
        internal static ReaderData createReader(string firstName, string lastName, IsoGender gender, DateTime dayOfBirth, int telephone, string city, string homeAddress)
        {
            var person = new ReaderData
            {
                ID = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DoB = dayOfBirth,
                Telephone = telephone,
                CityID = city,
                HomeAddress = homeAddress
           

            };
            return person;
        }
        protected override IEnumerable<ReaderData> getEntities => new[] {
            createReader("Harry", "Potter", IsoGender.Male, new DateTime(1980, 07, 31), 53051233, "Tartu", "Anne 2"),
            createReader("Hermione", "Grenger", IsoGender.Female, new DateTime(1979, 09, 19), 51233233, "Tallinn", "Narva mnt 1"),
            createReader("Ronald", "Weasley", IsoGender.Male, new DateTime(1980, 03, 01), 51233233, "Tallinn", "Narva mnt 57")
        };
    }
}
