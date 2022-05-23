using Microsoft.EntityFrameworkCore;
using Rakendus.Data;
using Rakendus.Domain;

namespace Rakendus.Infra
{
    //TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

    //TODO To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.

    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
    {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c, s) { }

    }


}
