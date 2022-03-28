using Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rakendus.Data.Party;

namespace LibaryDataBase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookData> Books { get; set; }
        public DbSet<LibaryDataBase.Data.BookItem> BookItem { get; set; }
        public DbSet<LibaryDataBase.Data.LoanedBook> LoanedBook { get; set; }
    }
}