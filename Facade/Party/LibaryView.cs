using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Facade.Party
{
    public sealed class LibaryView: UniqueView
    {
        [DisplayName("Name")] public string? Name { get; set; }
        [DisplayName("Address")] public string? Address { get; set; }
        [DisplayName("City")]  public string? CityID { get; set; }

    }
    public sealed class LibaryViewFactory : BaseViewFactory<LibaryView, Libary, LibaryData>
    {
        protected override Libary toEntity(LibaryData d) => new(d);
    }
}
