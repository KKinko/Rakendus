using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Data.Party;

namespace LibaryDataBase.Pages.Books
{
    
    //TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

    //TODO To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public class BooksPage : PageModel
    {
        private readonly ApplicationDbContext context;
        [BindProperty] public BookView Book { get; set; }
        public IList<BookView> Books { get; set; }
        public BooksPage(ApplicationDbContext c) => context = c;
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
            var d = new BookViewFactory().Create(Book).Data;

            context.Books.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Book = await getBook(id);
            return Book == null ? NotFound() : Page();
        }
        private async Task<BookView> getBook(string id)
        {
            if (id == null) return null;
            var d = await context.Books.FirstOrDefaultAsync(m => m.IsbnID == id);
            if (d == null) return null;
            return new BookViewFactory().Create(new Book(d));
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Book = await getBook(id);
            return Book == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Books.FindAsync(id);

            if (d != null)
            {
                context.Books.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Book = await getBook(id);
            return Book == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var d = new BookViewFactory().Create(Book).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookExists(Book.IsbnID))
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
        private bool bookExists(string id)
            => context.Books.Any(e => e.IsbnID == id);

        public async Task<IActionResult> OnGetIndexAsync()
        {
            Books = new List<BookView>();
            var list = await context.Books.ToListAsync();
            foreach (var d in list)
            {
                var v = new BookViewFactory().Create(new Book(d));
                Books.Add(v);
            }
            return Page();
        }
    }
}
