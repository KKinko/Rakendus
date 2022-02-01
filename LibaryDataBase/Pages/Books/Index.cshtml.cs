#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibaryDataBase.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly LibaryDataBase.Data.ApplicationDbContext _context;

        public IndexModel(LibaryDataBase.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookField { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Book
                                            orderby m.Field
                                            select m.Field;

            var books = from m in _context.Book
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }
            Book = await _context.Book.ToListAsync();

            if (!string.IsNullOrEmpty(BookField))
            {
                books = books.Where(x => x.Field == BookField);
            }
            Books = new SelectList(await genreQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
