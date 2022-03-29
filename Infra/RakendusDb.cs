using Microsoft.EntityFrameworkCore;
using Rakendus.Data.Party;

namespace Rakendus.Infra
{
    public sealed class RakendusDb : DbContext
    {
        public RakendusDb(DbContextOptions<RakendusDb> options) : base(options) { }
        public DbSet<BookData>? Books { get; set; }
        public DbSet<ItemData>? Items { get; set; }
        public DbSet<LoanedData>? Loans { get; set; }


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

        }

    }

}
