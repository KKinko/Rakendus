using Microsoft.EntityFrameworkCore;
using Rakendus.Data.Party;

namespace Rakendus.Infra
{
    public sealed class RakendusDb : DbContext
    {
        public RakendusDb(DbContextOptions<RakendusDb> options) : base(options) { }
        public DbSet<BookData>? Books { get; internal set; }
        public DbSet<ReaderData>? Readers { get; internal set; }
        public DbSet<ItemData>? Items { get; internal set; }
        public DbSet<LoanedData>? Loans { get; internal set; }
        public DbSet<CountryData>? Countries { get; internal set; }
        public DbSet<CurrencyData>? Currencies { get; internal set; }
        public DbSet<CityData>? Cities { get; internal set; }
        public DbSet<CountryCurrencyData>? CountryCurrencies { get; internal set; }
        public DbSet<LibaryData>? Libaries { get; internal set; }
        public DbSet<AuthorData>? Authors { get; internal set; }
        public DbSet<BookAuthorData>? BooksAuthors { get; internal set; }



        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b)
        {
            var s = nameof(RakendusDb)[0..^2];
            _ = (b?.Entity<BookData>()?.ToTable(nameof(Books), s));
            _ = (b?.Entity<ItemData>()?.ToTable(nameof(Items), s));
            _ = (b?.Entity<LoanedData>()?.ToTable(nameof(Loans), s));
            _ = (b?.Entity<ReaderData>()?.ToTable(nameof(Readers), s));
            _ = (b?.Entity<CountryData>()?.ToTable(nameof(Countries), s));
            _ = (b?.Entity<CurrencyData>()?.ToTable(nameof(Currencies), s));
            _ = (b?.Entity<CityData>()?.ToTable(nameof(Cities), s));
            _ = (b?.Entity<LibaryData>()?.ToTable(nameof(Libaries), s));
            _ = (b?.Entity<AuthorData>()?.ToTable(nameof(Authors), s));
            _ = (b?.Entity<BookAuthorData>()?.ToTable(nameof(BooksAuthors), s));
            _ = (b?.Entity<CountryCurrencyData>()?.ToTable(nameof(CountryCurrencies), s));

        }

    }

}
