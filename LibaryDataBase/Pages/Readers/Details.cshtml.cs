#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;

namespace LibaryDataBase.Pages.Readers
{
    public class DetailsModel : PageModel
    {
        private readonly LibaryDataBase.Data.ApplicationDbContext _context;

        public DetailsModel(LibaryDataBase.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Reader Reader { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reader = await _context.Reader.FirstOrDefaultAsync(m => m.ID == id);

            if (Reader == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
