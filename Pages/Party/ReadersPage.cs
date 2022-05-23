using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Pages.Party
{
    [Authorize]
    public class ReadersPage : PagedPage<ReaderView, Reader, IReadersRepo>
    {
        private readonly ICitiesRepo cities;
        private readonly ILoansRepo loans;
        public ReadersPage(IReadersRepo r, ICitiesRepo c, ILoansRepo l) : base(r)
        { 
            cities = c;
            loans = l;
        
        }
             

        protected override Reader toObject(ReaderView? item) => new ReaderViewFactory().Create(item);

        protected override ReaderView toView(Reader? entity) => new ReaderViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(ReaderView.ID),
            nameof(ReaderView.FirstName),
            nameof(ReaderView.LastName),
            nameof(ReaderView.Gender),
            nameof(ReaderView.DoB),
            nameof(ReaderView.Telephone),
            nameof(ReaderView.CityID),
            nameof(ReaderView.LoanedID),
            nameof(ReaderView.Telephone),
            nameof(ReaderView.HomeAddress),
            nameof(ReaderView.ReaderFullName)
        };
        public IEnumerable<SelectListItem> Cities
            => cities?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Genders
        => Enum.GetValues<IsoGender>()?
           .Select(x => new SelectListItem(x.Description(), x.ToString()))
           ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Loans
       => loans?.GetAll(x => x.ID)?
            .Select(x => new SelectListItem(x.ID, x.ID))
            ?? new List<SelectListItem>();

        public string LoanedName(string? loanedID = null)
           => Loans?.FirstOrDefault(x => x.Value == (loanedID ?? string.Empty))?.Text ?? "Unspecified";

        public string CityName(string? cityID = null)
           => Cities?.FirstOrDefault(x => x.Value == (cityID ?? string.Empty))?.Text ?? "Unspecified";

        public string GenderDescription(IsoGender? x)
          => (x ?? IsoGender.NotApplicable).Description();

        public override object? GetValue(string name,ReaderView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(ReaderView.CityID) ? CityName(r as string) 
                : name == nameof(ReaderView.Gender) ? GenderDescription((IsoGender) r)
                : name == nameof(ReaderView.LoanedID) ? LoanedName(r as string)
                : r;
        }



    }
}

