using Microsoft.EntityFrameworkCore;
using Rakendus.Data;

namespace Rakendus.Infra.Initializers
{
    public abstract class BaseInitializer<TData> where TData : EntityData
    {
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;
        protected BaseInitializer(DbContext? c, DbSet<TData>? s)
        {
            db = c;
            set = s;
        }
        public void Init()
        {
            if (set?.Any() ?? true) return;
            set.AddRange(getEntities);
            db?.SaveChanges();
        }
        protected abstract IEnumerable<TData> getEntities { get; }
    }

    public static class RakendusDbInitializer
    {
        public static void Init(RakendusDb? db)
        {
            new BooksInitializer(db).Init();
            new ReadersInitializer(db).Init();
            new ItemsInitializer(db).Init();
            new LoanedInitializer(db).Init();
        }
    }
}
