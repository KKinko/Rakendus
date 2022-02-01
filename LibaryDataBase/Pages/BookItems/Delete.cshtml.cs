#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;

namespace LibaryDataBase.Pages.BookItems
{
    public class DeleteModel : PageModel
    {
        private readonly LibaryDataBase.Data.ApplicationDbContext _context;

        public DeleteModel(LibaryDataBase.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookItem BookItem { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookItem = await _context.BookItem.FirstOrDefaultAsync(m => m.BookID == id);

            if (BookItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookItem = await _context.BookItem.FindAsync(id);

            if (BookItem != null)
            {
                _context.BookItem.Remove(BookItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
