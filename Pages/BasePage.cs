using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rakendus.Facade;
using Rakendus.Domain;

namespace Rakendus.Pages
{
    public abstract class BasePage<TView,TEntity, TRepo> : PageModel 
        where TView: BaseView 
        where TRepo : IBaseRepo<TEntity>
        where TEntity : Entity
    {
        private readonly TRepo repo;
        protected abstract TView toView(TEntity? entity);
        protected abstract TEntity toObject(TView? item);
        
        public string ItemId => Item?.ID ?? string.Empty;
        [BindProperty] public TView? Item { get; set; }
        public IList<TView>? Items { get; set; }
        public BasePage(TRepo r) => repo = r;
        public IActionResult OnGetCreate() => Page();
       
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();

            await repo.AddAsync(toObject(Item));

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();

            await repo.DeleteAsync(id);

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();

            var obj = toObject(Item);
            var updated = await repo.UpdateAsync(obj);

            if (!updated) return NotFound();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            Items = new List<TView>();
            var list = await repo.GetAsync();
            foreach (var obj in list)
            {
                var v = toView(obj);
                Items.Add(v);
            }
            return Page();
        }

        private async Task<TView> getItem(string id) 
            => toView(await repo.GetAsync(id));
        
    }
}

