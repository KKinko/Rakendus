namespace Rakendus.Data
{
    public abstract class PersonData : UniqueData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DoB { get; set; }
    }
}
