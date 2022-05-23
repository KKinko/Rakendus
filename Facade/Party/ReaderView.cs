using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel;

namespace Rakendus.Facade.Party
{
    public sealed class ReaderView : PersonView
    {
        [DisplayName("Gender")] public IsoGender? Gender { get; set; }
        [DisplayName("Telephone")] public int? Telephone { get; set; }
        [DisplayName("City")] public string? CityID { get; set; }
        [DisplayName("Home Address")] public string? HomeAddress { get; set; }
        [DisplayName("Loans")] public string? LoanedID { get; set; }
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