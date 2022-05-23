﻿using Rakendus.Facade;
using Rakendus.Domain;

namespace Rakendus.Pages
{
    public abstract class FilteredPage<TView, TEntity, TRepo> : CrudPage<TView, TEntity, TRepo>
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : IFilteredRepo<TEntity>
    {
        protected FilteredPage(TRepo r) : base(r) { }
        public string? CurrentFilter
        {
            get => repo.CurrentFilter;
            set => repo.CurrentFilter = value;
        }
    }

}

