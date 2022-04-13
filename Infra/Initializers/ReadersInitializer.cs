using Rakendus.Data.Party;

namespace Rakendus.Infra.Initializers
{
    public sealed class ReadersInitializer : BaseInitializer<ReaderData>
    {
        public ReadersInitializer(RakendusDb? db) : base(db, db?.Readers) { }
        internal static ReaderData createReader(string firstName, string lastName, bool gender, DateTime dayOfBirth, int telephone, string city, string homeAddress, string education, string emailAddress )
        {
            var person = new ReaderData
            {
                ID = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DoB = dayOfBirth,
                Telephone = telephone,
                City = city,
                HomeAddress = homeAddress,
                Education = education,
                EmailAddress = emailAddress

            };
            return person;
        }
        protected override IEnumerable<ReaderData> getEntities => new[] {
            createReader("Harry", "Potter", false, new DateTime(1980, 07, 31), 53051233, "Tartu", "Anne 2", "Põhiharidus", "harrypotter@gmail.com"),
            createReader("Hermione", "Grenger", true, new DateTime(1979, 09, 19), 51233233, "Tallinn", "Narva mnt 1", "Keskharidus", "hermionegrenger@gmail.com"),
            createReader("Ronald", "Weasley", false, new DateTime(1980, 03, 01), 51233233, "Tallinn", "Narva mnt 57", "Keskharidus", "ronaldweasley@gmail.com")
        };
    }
}
