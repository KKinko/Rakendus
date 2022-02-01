using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibaryDataBase.Data;

namespace LibaryDataBase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LibaryDataBase.Data.Reader> Reader { get; set; }
        public DbSet<LibaryDataBase.Data.Book> Book { get; set; }
        public DbSet<LibaryDataBase.Data.BookItem> BookItem { get; set; }
        public DbSet<LibaryDataBase.Data.LoanedBook> LoanedBook { get; set; }
    }
}