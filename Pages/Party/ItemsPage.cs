using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages
{
    public class ItemsPage : BasePage<ItemView, Item, IItemsRepo>
    {
        public ItemsPage(IItemsRepo r) : base(r) { }

        protected override Item toObject(ItemView? item) => new ItemViewFactory().Create(item);

        protected override ItemView toView(Item? entity) => new ItemViewFactory().Create(entity);
    }
}
