using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    public class ItemsPage : PagedPage<ItemView, Item, IItemsRepo>
    {
        private readonly IBooksRepo books;
        private readonly ILibariesRepo libaries;
        public ItemsPage(IItemsRepo r, IBooksRepo b, ILibariesRepo l ) : base(r) 
        {
            books = b;
            libaries = l;
        }

        protected override Item toObject(ItemView? item) => new ItemViewFactory().Create(item);

        protected override ItemView toView(Item? entity) => new ItemViewFactory().Create(entity);

        public override string[] IndexColumns { get; } = new[] {
            nameof(ItemView.ID),
            nameof(ItemView.BookID),
            nameof(ItemView.LibaryID)
        };
        public IEnumerable<SelectListItem> Books
            => books?.GetAll(x => x.Isbn)?
            .Select(x => new SelectListItem(x.Isbn, x.ID))
            ?? new List<SelectListItem>();

        public string BookName(string? bookID = null)
            => Books?.FirstOrDefault(x => x.Value == (bookID ?? string.Empty))?.Text ?? "Unspecified";

       
        public IEnumerable<SelectListItem> Libaries
            => libaries?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();

        public string LibaryName(string? libaryID = null)
            => Libaries?.FirstOrDefault(x => x.Value == (libaryID ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, ItemView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(ItemView.BookID) ? BookName(r as string) 
                :  name == nameof(ItemView.LibaryID) ? LibaryName(r as string) 
                : r;
        }
    }
}
