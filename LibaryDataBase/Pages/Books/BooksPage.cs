using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Data.Party;
using Rakendus.Infra.Party;

namespace LibaryDataBase.Pages.Books
{
    
    
    public class BooksPage : PageModel
    {
        private readonly IBooksRepo repo;
        [BindProperty] public BookView Book { get; set; }
        public IList<BookView> Books { get; set; }
        public BooksPage(ApplicationDbContext c) => repo = new BooksRepo(c, c.Books);

        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            
            await repo.AddAsync(new BookViewFactory().Create(Book));

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Book = await getBook(id);
            return Book == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Book = await getBook(id);
            return Book == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();

            await repo.DeleteAsync(id);
            
            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Book = await getBook(id);
            return Book == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            
            var obj = new BookViewFactory().Create(Book);
            var updated = await repo.UpdateAsync(obj);
            
            if (!updated) return NotFound();
            
            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetIndexAsync()
        {
            Books = new List<BookView>();
            var list = await repo.GetAsync();
            foreach (var obj in list)
            {
                var v = new BookViewFactory().Create(obj);
                Books.Add(v);
            }
            return Page();
        }

        private async Task<BookView> getBook(string id) => new BookViewFactory().Create(await repo.GetAsync(id));
        }
    }

