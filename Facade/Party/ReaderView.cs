using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade
{
    public class ReaderView
    {
        [Required] public string ID { get; set; }

        [DisplayName("First name")] public string? FirstName { get; set; }

        [DisplayName("Last name")] [Required] public string? LastName { get; set; }

        [DisplayName("Gender")] public bool? Gender { get; set; }

        [DisplayName("Date of birth")] public DateTime? DoB { get; set; }
        [DisplayName("Telephone")] public int? Telephone { get; set; }
        [DisplayName("City")] public string? City { get; set; }
        [DisplayName("Home Address")] public string? HomeAddress { get; set; }
        [DisplayName("Education")] public string? Education { get; set; }
        [DisplayName("Email address")] public string? EmailAddress { get; set; }
        [DisplayName("Reader FullName")] public string? ReaderFullName { get; set; }
    }
}