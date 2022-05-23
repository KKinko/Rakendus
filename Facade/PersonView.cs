using System.ComponentModel;

namespace Rakendus.Facade
{
    public abstract class PersonView : UniqueView
    {
        [DisplayName("Firstname")] public string? FirstName { get; set; }
        [DisplayName("Lastname")] public string? LastName { get; set; }
        [DisplayName("Date Of Birth")] public DateTime? DoB { get; set; }
    }
}
