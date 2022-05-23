using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class ItemViewFactoryTests :  ViewFactoryTests<ItemViewFactory, ItemView, Item, ItemData>
    {
        protected override Item toObject(ItemData d) => new(d);
    }
}
