using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade
{
    public sealed class ReaderView : BaseView
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
    public sealed class ReaderViewFactory : BaseViewFactory<ReaderView, Reader, ReaderData>
    {
        protected override Reader toEntity(ReaderData d) => new(d);
        public override ReaderView Create(Reader? e)
        {
            var v = base.Create(e);
            v.ReaderFullName = e?.ToString();
            return v;
        }
    }
}