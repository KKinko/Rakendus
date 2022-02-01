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
    public class IndexModel : PageModel
    {
        private readonly LibaryDataBase.Data.ApplicationDbContext _context;

        public IndexModel(LibaryDataBase.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BookItem> BookItem { get;set; }

        public async Task OnGetAsync()
        {
            BookItem = await _context.BookItem.ToListAsync();
        }
    }
}
