using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class CityViewFactoryTests : ViewFactoryTests<CityViewFactory, CityView, City, CityData>
    {
        protected override City toObject(CityData d) => new(d);
    }
}