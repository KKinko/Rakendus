using Data;
using Microsoft.EntityFrameworkCore;
using Rakendus.Domain.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakendus.Infra.Party
{
    public class ReadersRepo : Repo<Reader, ReaderData>, IReadersRepo {
        public ReadersRepo(DbContext c, DbSet<ReaderData> s) : base(c, s) { }
        protected override Reader toDomain(ReaderData d) => new Reader(d);
    }
}
