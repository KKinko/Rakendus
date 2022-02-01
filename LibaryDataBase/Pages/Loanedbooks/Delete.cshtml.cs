#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;

namespace LibaryDataBase.Pages.Loanedbooks
{
    public class DeleteModel : PageModel
    {
        private readonly LibaryDataBase.Data.ApplicationDbContext _context;

        public DeleteModel(LibaryDataBase.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoanedBook LoanedBook { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoanedBook = await _context.LoanedBook.FirstOrDefaultAsync(m => m.LoanedID == id);

            if (LoanedBook == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoanedBook = await _context.LoanedBook.FindAsync(id);

            if (LoanedBook != null)
            {
                _context.LoanedBook.Remove(LoanedBook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
