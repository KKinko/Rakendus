using Rakendus.Data.Party;
using Rakendus.Domain.Party;

namespace Rakendus.Facade.Party
{
    public sealed class AuthorView: PersonView {}
    public sealed class AuthorViewFactory : BaseViewFactory<AuthorView, Author, AuthorData>
    {
        protected override Author toEntity(AuthorData d) => new(d);
    }
}
