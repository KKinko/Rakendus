﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;

namespace LibaryDataBase.Pages.BookItems
{
    public class EditModel : PageModel
    {
        private readonly LibaryDataBase.Data.ApplicationDbContext _context;

        public EditModel(LibaryDataBase.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookItemExists(BookItem.BookID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookItemExists(string id)
        {
            return _context.BookItem.Any(e => e.BookID == id);
        }
    }
}
