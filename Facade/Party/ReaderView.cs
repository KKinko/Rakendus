using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public sealed class ReaderView : BaseView
    {

        [Display(Name = "First name")] public string? FirstName { get; set; }
        [Display(Name = "Last name")] public string? LastName { get; set; }
        [Display(Name = "Gender")] public bool? Gender { get; set; }
        [Display(Name = "Date of birth")] public DateTime? DoB { get; set; }
        [Display(Name = "Telephone")] public int? Telephone { get; set; }
        [Display(Name = "City")] public string? City { get; set; }
        [Display(Name = "Home Address")] public string? HomeAddress { get; set; }
        [Display(Name = "Education")] public string? Education { get; set; }
        [Display(Name = "Email address")] public string? EmailAddress { get; set; }
        [Display(Name = "Reader FullName")] public string? ReaderFullName { get; set; }

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