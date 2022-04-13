using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade.Party
{
    public sealed class ItemView: BaseView
    {
        [Display(Name = "Isbn")] public string? Isbn { get; set; }
        [Display(Name = "Libary")] public string? Libary { get; set; }
    }
    public sealed class ItemViewFactory : BaseViewFactory<ItemView, Item, ItemData>
    {
        protected override Item toEntity(ItemData d) => new(d);
       
    }
}
