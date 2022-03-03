using Rakendus.Data;

namespace Data
{
    public class ReaderData : EntityData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DoB { get; set; }
        public int? Telephone { get; set; }
        public string? City { get; set; }
        public string? HomeAddress { get; set; }
        public string? Education { get; set; }
        public string? EmailAddress { get; set; }
    }
}