using Domain;
using Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rakendus.Facade.Party;

namespace LibaryDataBase.Pages.Readers
{
    // TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    // TODO To protect from overposting attacks, enable the specific properties you want to bind to.
    // TODO For more details, see https://aka.ms/RazorPagesCRUD.

    public class ReadersPage : PageModel {
        private readonly LibaryDataBase.Data.ApplicationDbContext context;
        [BindProperty] public ReaderView Reader { get; set; }
        public IList<ReaderView> Readers { get; set; }
        public ReadersPage(LibaryDataBase.Data.ApplicationDbContext c) => context = c;
        public IActionResult OnGetCreate()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var d = new ReaderViewFactory().Create(Reader).Data;

            context.Readers.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string? id)
        {
            Reader = await getReader(id);
            return Reader == null ? NotFound() : Page();
        }

        private async Task<ReaderView> getReader(object id) { 
            if (id == null) return null;
            var d = await context.Readers.FirstOrDefaultAsync(m => m.ID == id);
            if (d == null) return null;
            return new ReaderViewFactory().Create(new Domain.Reader(d)); 
        }

        public async Task<IActionResult> OnGetDeliteAsync(string? id){
            Reader = await getReader(id);
            return Reader == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeliteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Readers.FindAsync(id);

            if (d != null)
            {
                context.Readers.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id){   
            Reader = await getReader(id);
            return Reader == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var d = new ReaderViewFactory().Create(Reader).Data;
            context.Attach(d).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderExists(d.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index", "Index");
        }
        private bool ReaderExists(string id)
            => context.Readers.Any(e => e.ID == id);
        public async Task OnGetIndexAsync()
        {
            var list = await context.Readers.ToListAsync();
            Readers = new List<ReaderView>();
            foreach (var d in list)
            {
                var v = new ReaderViewFactory().Create(new Reader(d));
                Readers.Add(v);
            }
        }
    }
}