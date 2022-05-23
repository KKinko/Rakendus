using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    public class LibariesPage : PagedPage<LibaryView, Libary, ILibariesRepo>
    {
        private readonly ICitiesRepo cities;
        public LibariesPage(ILibariesRepo r, ICitiesRepo c) : base(r)
        { 
            cities = c; 
        }

        protected override Libary toObject(LibaryView? item) => new LibaryViewFactory().Create(item);

        protected override LibaryView toView(Libary? entity) => new LibaryViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(LibaryView.ID),
            nameof(LibaryView.Name),
            nameof(LibaryView.Address),
            nameof(LibaryView.CityID)
        };
        public IEnumerable<SelectListItem> Cities
          => cities?.GetAll(x => x.Name)?
          .Select(x => new SelectListItem(x.Name, x.ID))
          ?? new List<SelectListItem>();
        public string CityName(string? cityID = null)
           => Cities?.FirstOrDefault(x => x.Value == (cityID ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, LibaryView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(LibaryView.CityID) ? CityName(r as string)
                : r;
        }
    }
}

