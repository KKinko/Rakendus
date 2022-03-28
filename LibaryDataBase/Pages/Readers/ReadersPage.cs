using Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;
using Rakendus.Infra.Party;

namespace LibaryDataBase.Pages.Readers
{
    public class ReadersPage : PageModel {
        private readonly IReadersRepo repo;
        [BindProperty] public ReaderView Item { get; set; }
        public IList<ReaderView> Items { get; set; }
        public ReadersPage(LibaryDataBase.Data.ApplicationDbContext c) => repo = new ReadersRepo(c, c.Readers);
        public IActionResult OnGetCreate() => Page();
        public string ItmeId => Item?.ID ?? string.Empty;
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new ReaderViewFactory().Create(Item));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string? id)
        {
            Item = await getReader(id);
            return Item == null ? NotFound() : Page();
        }

        private async Task<ReaderView> getReader(string id) => new ReaderViewFactory().Create(await repo.GetAsync(id)); 
        public async Task<IActionResult> OnGetDeleteAsync(string id){
            Item = await getReader(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id){   
            Item = await getReader(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync() {
            if (!ModelState.IsValid) return Page();
            var obj = new ReaderViewFactory().Create(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync() {
            var list = await repo.GetAsync();
            Items = new List<ReaderView>();
            foreach (var obj in list)
            {
                var v = new ReaderViewFactory().Create(obj);
                Items.Add(v);
            }
            return Page();
        }
    }
}