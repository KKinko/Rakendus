using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public sealed class ItemView: UniqueView
    {
        [DisplayName("Isbn")] public string? BookID { get; set; }
        [DisplayName("Libary")] public string? LibaryID { get; set; }
    }
    public sealed class ItemViewFactory : BaseViewFactory<ItemView, Item, ItemData>
    {
        protected override Item toEntity(ItemData d) => new(d);
       
    }
}
