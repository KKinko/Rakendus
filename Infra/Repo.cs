﻿using Microsoft.EntityFrameworkCore;
using Rakendus.Data;
using Rakendus.Domain;

namespace Rakendus.Infra
{
    //TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

    //TODO To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.

    public abstract class Repo<TDomain, TData> : IRepo<TDomain> where TDomain : Entity<TData>, new() where TData : EntityData, new()
    {
        private readonly DbContext db;
        private readonly DbSet<TData> set;
        protected Repo(DbContext c, DbSet<TData> s) 
        { 
            db = c;
            set = s;
        }

        protected abstract TDomain toDomain(TData d);

        public bool Add(TDomain obj) => AddAsync(obj).GetAwaiter().GetResult();
        public bool Delete(string id) => DeleteAsync(id).GetAwaiter().GetResult();
        public List<TDomain> Get() => GetAsync().GetAwaiter().GetResult();
        public TDomain Get(string id) => GetAsync(id).GetAwaiter().GetResult();
        public bool Update(TDomain obj) => UpdateAsync(obj).GetAwaiter().GetResult();
        
        public async Task<bool> AddAsync(TDomain obj)
        {
            var d = obj.Data;
            try
            {
                await set.AddAsync(d);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> DeleteAsync(string id)
        {
            try 
            {
                var d = await set.FindAsync(id);

                if (d == null) return false;
                set.Remove(d);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        public async Task<List<TDomain>> GetAsync()
        {
            try 
            {
            var items = new List<TDomain>();
            var list = await set.ToListAsync();
            foreach (var d in list) items.Add(toDomain(d));
            return items;
            }
            catch
            {
                return new List<TDomain>();
            }
        }
        public async Task<TDomain> GetAsync(string id)
        {
            try
            {
                if (id == null) return new TDomain();
                var d = await set.FirstOrDefaultAsync(x => x.IsbnID == id);
                return d == null ? new TDomain() : toDomain(d);
            }
            catch
            {
                return new TDomain();
            }
            
        }
        
        public async Task<bool> UpdateAsync(TDomain obj)
        {
            try
            {
                var d = obj.Data;
                db.Attach(d).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}