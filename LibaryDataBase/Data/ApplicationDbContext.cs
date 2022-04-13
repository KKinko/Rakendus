using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rakendus.Infra;

namespace LibaryDataBase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            initializeTables(b);
        }
        private static void initializeTables(ModelBuilder b)
        {
            RakendusDb.InitializeTables(b);
        }
    }
}