using Data;
using Microsoft.EntityFrameworkCore;
namespace Rakendus.Infra.Party
{
    public sealed class ReaderDb : DbContext {
        public ReaderDb(DbContextOptions<ReaderDb> options)
            : base(options) { }
        public DbSet<ReaderData> Readers { get; set; }
    }
}
