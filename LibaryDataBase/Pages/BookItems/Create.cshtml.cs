#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibaryDataBase.Data;

namespace LibaryDataBase.Pages.BookItems
{
    public class CreateModel : PageModel
    {
        private readonly LibaryDataBase.Data.ApplicationDbContext _context;

        public CreateModel(LibaryDataBase.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookItem BookItem { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookItem.Add(BookItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
